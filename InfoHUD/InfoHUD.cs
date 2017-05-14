using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using InfoCore;
using InfoHUD.Properties;

namespace InfoHUD
{
    public class InfoHUD : IDisposable
    {
        const int COL_BACKGROUND = -1;
        const int COL_TEXT = -16777216;
        const int COL_EDGE = -8355712;

        Device XDevice;
        Sprite XSprite;
        public InfoHUD(Device xdevice)
        {
            XDevice = xdevice;
            XSprite = new Sprite(XDevice);
            new Thread(new ThreadStart(Init)).Start();
        }

        class InfoContainer
        {
            public InfoObject Object;
            public Point Location;
            public long NextRefresh;
        }

        class RefreshComparer : Comparer<InfoContainer>
        {
            public override int Compare(InfoContainer x, InfoContainer y)
            {
                if (x.NextRefresh == y.NextRefresh)
                    return 0;
                else
                    if ((x.NextRefresh > y.NextRefresh || x.NextRefresh == Timeout.Infinite) && y.NextRefresh != -1)
                        return 1;
                    else return -1;
            }
        }

        List<InfoContainer> InfoContainers;
        Timer RefreshTimer;
        Bitmap HUDBitmap;
        Graphics HUDGraphics;
        Texture HUDTexture;
        Size HUDSize;
        Point HUDGrid, HUDPosition;
        Rectangle HUDRectangle;
        Brush HUDBackgroundBrush;
        bool HUDLoaded;
        int HUDState;
        int HUDHeight;
        void Init()
        {
            RefreshThread = Thread.CurrentThread;
            HUDBackgroundBrush = new SolidBrush(Color.FromArgb(COL_BACKGROUND));
            HUDSize = Settings.Default.HUDSize;
            HUDBitmap = new Bitmap((HUDSize.Width + HUDSize.Height) * 18 + 4, HUDSize.Height * 18 + 4);
            HUDGraphics = Graphics.FromImage(HUDBitmap);
            HUDGraphics.SmoothingMode = SmoothingMode.AntiAlias;
            HUDGraphics.DrawLines(new Pen(Color.FromArgb(COL_EDGE), 4), new Point[] { new Point(2, HUDBitmap.Height), new Point(HUDSize.Height * 9 + 2, 2), new Point(HUDSize.Width * 18 + HUDSize.Height * 9 + 2, 2), new Point(HUDBitmap.Width - 2, HUDBitmap.Height) });
            HUDGraphics.FillPolygon(HUDBackgroundBrush, new Point[] { new Point(2, HUDBitmap.Height), new Point(HUDSize.Height * 9 + 2, 2), new Point(HUDSize.Width * 18 + HUDSize.Height * 9 + 2, 2), new Point(HUDBitmap.Width - 2, HUDBitmap.Height) });
            HUDGraphics.Flush(FlushIntention.Sync);
            HUDRectangle = new Rectangle(Point.Empty, HUDBitmap.Size);
            HUDTexture = new Texture(XDevice, HUDBitmap, Usage.None, Pool.Managed);
            HUDGrid = new Point(HUDSize.Height * 9 + 2, 4);
            HUDPosition = new Point(XDevice.DisplayMode.Width / 2 - HUDBitmap.Width / 2, XDevice.DisplayMode.Height);
            HUDState = HUDBitmap.Height;
            HUDHeight = HUDBitmap.Height;
            InfoContainers = new List<InfoContainer>();
            foreach (string item in Settings.Default.HUDObjects.Split(new char[] {'|'}))
            {
                string name = item.Split(new char[] { ':' })[0];
                string[] position = item.Split(new char[] { ':' })[1].Split(new char[] { ',' });
                
                InfoContainer IC = new InfoContainer();
                IC.Object = LoadInfoObject(name);
                IC.Location = new Point(Convert.ToInt32(position[0]) * 18, Convert.ToInt32(position[1]) * 18);
                IC.NextRefresh = 0;
                InfoContainers.Add(IC);
            }
            RefreshTimer = new Timer(RefreshCallback, null, 100, Timeout.Infinite);
            RefreshThread = null;
        }

        Thread RefreshThread;
        void RefreshCallback(object o)
        {
            RefreshThread = Thread.CurrentThread;
            long refreshTime = InfoContainers[0].NextRefresh;
            foreach (InfoContainer IC in InfoContainers)
            {
                if (IC.NextRefresh == Timeout.Infinite) continue;
                IC.NextRefresh -= refreshTime;
                if (IC.NextRefresh == 0)
                {
                    Bitmap newBitmap = IC.Object.Draw();
                    if (newBitmap != null)
                    {
                        HUDGraphics.FillRectangle(HUDBackgroundBrush, HUDGrid.X + IC.Location.X, HUDGrid.Y + IC.Location.Y, IC.Object.Size.Width * 18 - 2, IC.Object.Size.Height * 18 - 2);
                        HUDGraphics.DrawImage(newBitmap, HUDGrid.X + IC.Location.X, HUDGrid.Y + IC.Location.Y, IC.Object.Size.Width * 18 - 2, IC.Object.Size.Height * 18 - 2);
                        newBitmap.Dispose();
                    }
                    IC.NextRefresh = IC.Object.RefreshTime;
                }
            }
            HUDGraphics.Flush(FlushIntention.Sync);
            Texture newTexture = new Texture(XDevice, HUDBitmap, Usage.None, Pool.Managed);
            Texture oldTexture = HUDTexture;
            lock (HUDTexture)
            {
                HUDTexture = newTexture;
            }
            oldTexture.Dispose();

            InfoContainers.Sort(new RefreshComparer());
            RefreshTimer.Change(InfoContainers[0].NextRefresh, Timeout.Infinite);
            GC.Collect();
            HUDLoaded = true;
            RefreshThread = null;
        }

        public static InfoObject LoadInfoObject(string name)
        {
            switch (name)
            {
                case "Logo":
                    return new IOLogo();
                    break;
                case "CPURAM":
                    return new IOCPURAM();
                    break;
                case "IP":
                    return new IOIP();
                    break;
                case "NET":
                    return new IONET();
                    break;
                case "Clock":
                    return new IOClock();
                    break;
                case "Date":
                    return new IODate();
                    break;
                case "User":
                    return new IOUser();
                    break;
                case "RSS":
                    return new IORSS();
                    break;
                default:
                    return null;
                    break;
            }
        }

        public void Draw()
        {
            if (HUDLoaded)
            {
                lock (HUDTexture)
                {
                    XSprite.Begin(SpriteFlags.AlphaBlend);
                    XSprite.Draw2D(HUDTexture, Rectangle.Empty, SizeF.Empty, HUDPosition, Color.White);
                    XSprite.End();
                    if (HUDState > 0)
                    {
                        HUDState -= 2;
                        HUDPosition = new Point(HUDPosition.X, XDevice.DisplayMode.Height - (HUDHeight - HUDState));
                    }
                }
            }
        }
        #region Dispose
        public bool IsDisposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected void Dispose(bool Disposing)
        {
            if (!IsDisposed)
            {
                if (Disposing && HUDLoaded)
                {
                    if (RefreshThread != null) RefreshThread.Join();
                    HUDLoaded = false;
                    RefreshTimer.Dispose();
                    RefreshTimer = null;
                    foreach (InfoContainer IC in InfoContainers)
                    {
                        IC.Object.Dispose();
                    }
                    InfoContainers.Clear();
                    HUDBackgroundBrush.Dispose();
                    HUDGraphics.Dispose();
                    HUDBitmap.Dispose();
                    HUDTexture.Dispose();
                    XSprite.Dispose();
                }
            }
        }
        ~InfoHUD()
        {
            Dispose(false);
        }
        #endregion

        #region Integrated InfoObjects
        class IOLogo : InfoObject
        {
            public IOLogo()
            {
                this.Size = new Size(4, 2);
                this.Name = "Axodox logo";
                this.RefreshTime = Timeout.Infinite;
            }
            public override System.Drawing.Bitmap Draw()
            {
                return Resources.axodox_logo;
            }
            protected override void Dispose(bool Disposing)
            {
                if (!IsDisposed)
                {
                    if (Disposing)
                    {
                    }
                }
            }
            ~IOLogo()
            {
                Dispose(false);
            }
        }

        class IORSS : InfoObject
        {
            private RSS.Feed[] Feeds;
            int[] ItemID;
            public IORSS()
            {
                this.Size = new Size(30, 2);
                this.Name = "RSS reader";
                this.RefreshTime = 5000;
                Feeds = new RSS.Feed[Settings.Default.IORSSFeeds.Count];
                for (int i = 0; i < Feeds.Length; i++)
                {
                    Feeds[i] = RSS.Feed.FromInternet(Settings.Default.IORSSFeeds[i]);
                    if (Feeds[i] == null) Feeds[i] = RSS.Feed.FromStrings(new string[] { "Feed at " + Settings.Default.IORSSFeeds[i] + " not available." });
                }
                ItemID = new int[] { 0, 0, 0 };
            }
            public override System.Drawing.Bitmap Draw()
            {
                Bitmap B = new Bitmap(Size.Width * 18 - 2, Size.Height * 18 - 2);
                Graphics G = Graphics.FromImage(B);
                G.CompositingMode = CompositingMode.SourceOver;
                G.TextRenderingHint = TextRenderingHint.AntiAlias;
                RSS.Item I = Feeds[ItemID[0]].Channels[ItemID[1]].Items[ItemID[2]];
                G.DrawString((I.Title != "" ? I.Title + ": " : "") + I.Description, new System.Drawing.Font("Tahoma", 9), new SolidBrush(Color.FromArgb(COL_TEXT)), new RectangleF(18, 0, B.Size.Width - 18, B.Size.Height), new StringFormat(StringFormatFlags.LineLimit | StringFormatFlags.FitBlackBox) { Trimming = StringTrimming.EllipsisWord });
                G.DrawImage(Resources.rss16, Point.Empty);
                G.Dispose();

                if (++ItemID[2] == Feeds[ItemID[0]].Channels[ItemID[1]].Items.Length)
                {
                    ItemID[2] = 0;
                    if (++ItemID[1] == Feeds[ItemID[0]].Channels.Length)
                    {
                        ItemID[1] = 0;
                        if (++ItemID[0] == Feeds.Length)
                        {
                            ItemID[0] = 0;
                        }
                    }
                }

                return B;
            }
            protected override void Dispose(bool Disposing)
            {
                if (!IsDisposed)
                {
                    if (Disposing)
                    {
                    }
                }
            }
            ~IORSS()
            {
                Dispose(false);
            }
        }

        class IOCPURAM : InfoObject
        {
            private PerformanceCounter PCCPU, PCRAM;
            public IOCPURAM()
            {
                this.Size = new Size(4, 2);
                this.Name = "CPURAM";
                this.RefreshTime = 1000;
                
                PCCPU = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
                PCRAM = new PerformanceCounter("Memory", "Available MBytes", true);
            }
            public override System.Drawing.Bitmap Draw()
            {
                Bitmap B = new Bitmap(Size.Width * 18 - 2, Size.Height * 18 - 2);
                Graphics G = Graphics.FromImage(B);
                G.TextRenderingHint = TextRenderingHint.AntiAlias;
                G.DrawImage(Resources.cpu16, Point.Empty);
                G.DrawImage(Resources.ram16, new Point(0, 19));
                G.DrawString(PCCPU.NextValue().ToString("F01") + "%", new System.Drawing.Font("Tahoma", 9), new SolidBrush(Color.FromArgb(COL_TEXT)), new PointF(18, 0));
                float mem = PCRAM.NextValue();
                G.DrawString((mem > 768 ? (mem / 1024).ToString("F02") + "GB" : mem.ToString("F01") + "MB"), new System.Drawing.Font("Tahoma", 9), new SolidBrush(Color.FromArgb(COL_TEXT)), new PointF(18, 19));
                G.Flush(FlushIntention.Sync);
                G.Dispose();
                return B;
            }
            protected override void Dispose(bool Disposing)
            {
                if (!IsDisposed)
                {
                    if (Disposing)
                    {
                        PCCPU.Dispose();
                        PCRAM.Dispose();
                        PCCPU = null;
                        PCRAM = null;
                    }
                }
            }
            ~IOCPURAM()
            {
                Dispose(false);
            }
        }

        class IOIP : InfoObject
        {
            public IOIP()
            {
                this.Size = new Size(8, 1);
                this.Name = "Internet";
                this.RefreshTime = 600000;
            }
            public override System.Drawing.Bitmap Draw()
            {
                Bitmap B = new Bitmap(Size.Width * 18 - 2, Size.Height * 18 - 2);
                Graphics G = Graphics.FromImage(B);
                G.DrawImage(Resources.network16, Point.Empty);
                string ip;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://whatismyipaddress.com/");
                request.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.0; hu; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.1";
                request.Timeout = 2000;
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.GetResponse();
                    StreamReader SR = new StreamReader(response.GetResponseStream());
                    ip = "IP " + Regex.Match(SR.ReadToEnd(), @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}").Value;
                    SR.Dispose();
                }
                catch
                {
                    ip = "Internet unavailable";
                }
                
                if (response != null) response.Close();
                G.TextRenderingHint = TextRenderingHint.AntiAlias;
                G.DrawString(ip, new System.Drawing.Font("Tahoma", 9), new SolidBrush(Color.FromArgb(COL_TEXT)), new PointF(18, 0));
                G.Flush(FlushIntention.Sync);
                G.Dispose();
                return B;
            }
            protected override void Dispose(bool Disposing)
            {
                if (!IsDisposed)
                {
                    if (Disposing)
                    {
                    }
                }
            }
            ~IOIP()
            {
                Dispose(false);
            }
        }

        class IONET : InfoObject
        {
            private PerformanceCounter PCDown, PCUp;
            public IONET()
            {
                this.Size = new Size(8, 1);
                this.Name = "NET";
                this.RefreshTime = 1000;

                if (PerformanceCounterCategory.InstanceExists(Settings.Default.IONETInterface, "Network Interface"))
                {
                    PCDown = new PerformanceCounter("Network Interface", "Bytes Received/sec", Settings.Default.IONETInterface, true);
                    PCUp = new PerformanceCounter("Network Interface", "Bytes Sent/sec", Settings.Default.IONETInterface, true);
                }
                else
                {
                    string[] instances = new PerformanceCounterCategory("Network Interface").GetInstanceNames();
                    try
                    {
                        PCDown = new PerformanceCounter("Network Interface", "Bytes Received/sec", instances[0], true);
                        PCUp = new PerformanceCounter("Network Interface", "Bytes Sent/sec", instances[0], true);
                    }
                    catch
                    {
                        this.RefreshTime = Timeout.Infinite;
                    }
                }
                
            }
            public override System.Drawing.Bitmap Draw()
            {
                Bitmap B = new Bitmap(Size.Width * 18 - 2, Size.Height * 18 - 2);
                Graphics G = Graphics.FromImage(B);
                G.DrawImage(Resources.down16, Point.Empty);
                G.DrawImage(Resources.up16, new Point(73, 0));
                G.TextRenderingHint = TextRenderingHint.AntiAlias;
                if (PCDown != null)
                {
                    G.DrawString((PCDown.NextValue() / 1024).ToString("F00") + "KB/s", new System.Drawing.Font("Tahoma", 9), new SolidBrush(Color.FromArgb(COL_TEXT)), new PointF(18, 0));
                    G.DrawString((PCUp.NextValue() / 1024).ToString("F00") + "KB/s", new System.Drawing.Font("Tahoma", 9), new SolidBrush(Color.FromArgb(COL_TEXT)), new PointF(90, 0));
                }
                G.Flush(FlushIntention.Sync);
                G.Dispose();
                return B;
            }
            public override void ShowOptions()
            {
                System.Windows.Forms.Form OF = new NETOptions();
                OF.ShowDialog();
                OF.Dispose();
            }
            protected override void Dispose(bool Disposing)
            {
                if (!IsDisposed)
                {
                    if (Disposing)
                    {
                        PCDown.Dispose();
                        PCUp.Dispose();
                        PCDown = null;
                        PCUp = null;
                    }
                }
            }
            ~IONET()
            {
                Dispose(false);
            }
        }

        class IOClock : InfoObject
        {
            public IOClock()
            {
                this.Size = new Size(5, 2);
                this.Name = "Clock";
                this.RefreshTime = 1000;
            }
            public override System.Drawing.Bitmap Draw()
            {
                Bitmap B = new Bitmap(Size.Width * 18 - 2, Size.Height * 18 - 2);
                Graphics G = Graphics.FromImage(B);
                G.TextRenderingHint = TextRenderingHint.AntiAlias;
                G.DrawString(DateTime.Now.ToString("HH:mm"), new System.Drawing.Font("Tahoma", 19), new SolidBrush(Color.FromArgb(COL_TEXT)), new PointF(0, 2));
                G.DrawString(DateTime.Now.ToString(".ss"), new System.Drawing.Font("Tahoma", 9), new SolidBrush(Color.FromArgb(COL_TEXT)), new PointF(67, 15));
                G.Flush(FlushIntention.Sync);
                G.Dispose();
                return B;
            }
            protected override void Dispose(bool Disposing)
            {
                if (!IsDisposed)
                {
                    if (Disposing)
                    {
                    }
                }
            }
            ~IOClock()
            {
                Dispose(false);
            }
        }

        class IODate : InfoObject
        {
            public IODate()
            {
                this.Size = new Size(8, 1);
                this.Name = "Date";
                this.RefreshTime = 86401000 - (long)DateTime.Now.TimeOfDay.TotalMilliseconds;
            }
            public override System.Drawing.Bitmap Draw()
            {
                Bitmap B = new Bitmap(Size.Width * 18 - 2, Size.Height * 18 - 2);
                Graphics G = Graphics.FromImage(B);
                G.DrawImage(Resources.datetime16, Point.Empty);
                G.TextRenderingHint = TextRenderingHint.AntiAlias;
                G.DrawString(DateTime.Now.ToString("D"), new System.Drawing.Font("Tahoma", 9), new SolidBrush(Color.FromArgb(COL_TEXT)), new PointF(16, 0));
                G.Flush(FlushIntention.Sync);
                G.Dispose();
                this.RefreshTime = 86401000 - (long)DateTime.Now.TimeOfDay.TotalMilliseconds;
                return B;
            }
            protected override void Dispose(bool Disposing)
            {
                if (!IsDisposed)
                {
                    if (Disposing)
                    {
                    }
                }
            }
            ~IODate()
            {
                Dispose(false);
            }
        }

        class IOUser : InfoObject
        {
            public IOUser()
            {
                this.Size = new Size(7, 1);
                this.Name = "User";
                this.RefreshTime = Timeout.Infinite;
            }
            public override System.Drawing.Bitmap Draw()
            {
                Bitmap B = new Bitmap(Size.Width * 18 - 2, Size.Height * 18 - 2);
                Graphics G = Graphics.FromImage(B);
                G.DrawImage(Resources.user16, Point.Empty);
                G.TextRenderingHint = TextRenderingHint.AntiAlias;
                G.DrawString(Environment.UserName, new System.Drawing.Font("Tahoma", 9), new SolidBrush(Color.FromArgb(COL_TEXT)), new PointF(16, 0));
                G.Flush(FlushIntention.Sync);
                G.Dispose();
                return B;
            }
            protected override void Dispose(bool Disposing)
            {
                if (!IsDisposed)
                {
                    if (Disposing)
                    {
                    }
                }
            }
            ~IOUser()
            {
                Dispose(false);
            }
        }
        #endregion
    }
}
