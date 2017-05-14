using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DirectXScreenSaver.Properties;

namespace DirectXScreenSaver
{
    public partial class MainForm : Form
    {
        static int FADE_STEP = Settings.Default.FadeSpeed;
        Device XDevice;
        Random XRandom;
        Timer XTimer;
        Sprite XSprite;

        Texture FadeTexture;
        Color FadeColor;
        Timer FadeTimer;
        int FadeState;

        InfoHUD.InfoHUD IH;
        public MainForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.Opaque, true);
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            Click += new EventHandler(MainForm_Click);
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            Cursor.Hide();

            if (Environment.ProcessorCount == 1)
            {
                XDevice = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing, new PresentParameters() { SwapEffect = SwapEffect.Discard, Windowed = true });
            }
            else
            {
                XDevice = new Device(0, DeviceType.Hardware, this, CreateFlags.SoftwareVertexProcessing | CreateFlags.MultiThreaded, new PresentParameters() { SwapEffect = SwapEffect.Discard, Windowed = true });
            }
            XDevice.RenderState.Lighting = false;
            XDevice.RenderState.AlphaBlendEnable = true;
            XDevice.RenderState.SourceBlend = Microsoft.DirectX.Direct3D.Blend.SourceAlpha;
            XDevice.RenderState.DestinationBlend = Microsoft.DirectX.Direct3D.Blend.InvSourceAlpha;
            XDevice.SamplerState[0].MinFilter = TextureFilter.Anisotropic;
            XDevice.SamplerState[0].MagFilter = TextureFilter.Anisotropic;

            XRandom = new Random();

            XTimer = new Timer();
            XTimer.Interval = 1000 / Settings.Default.FPS;
            XTimer.Tick += new EventHandler(XTimer_Tick);
            XTimer.Start();

            XSprite = new Sprite(XDevice);

            Bitmap B = new Bitmap(1, 1);
            B.SetPixel(0, 0, Color.White);
            FadeTexture = new Texture(XDevice, B, Usage.None, Pool.Managed);
            FadeColor = Color.FromArgb(10, Color.Black);
            FadeTimer = new Timer();
            FadeTimer.Interval = Settings.Default.FadeOutInterval*1000;
            FadeTimer.Tick += new EventHandler(FadeTimer_Tick);
            FadeTimer.Start();

            Particle.Init(XDevice);
            Particle.AddControlPoints(Settings.Default.ParticleControlCount);
            Particle.AddParticles(Settings.Default.ParticleCount);

            IH = new InfoHUD.InfoHUD(XDevice);
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Particle.ClearParticles();
            IH.Dispose();
            IH = null;
        }

        void FadeTimer_Tick(object sender, EventArgs e)
        {
            FadeState = 1;
            FadeTimer.Stop();
        }

        void MainForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        void XTimer_Tick(object sender, EventArgs e)
        {
            XDevice.BeginScene();
            XSprite.Begin(SpriteFlags.AlphaBlend);
            if (FadeState == 0)
            {
                XSprite.Draw2D(FadeTexture, new Rectangle(0, 0, 1, 1), new SizeF(XDevice.DisplayMode.Width, XDevice.DisplayMode.Height), Point.Empty, FadeColor);
                Particle.DrawParticles();
            }
            else
            {
                Particle.DrawParticles();
                XSprite.Draw2D(FadeTexture, new Rectangle(0, 0, 1, 1), new SizeF(XDevice.DisplayMode.Width, XDevice.DisplayMode.Height), Point.Empty, Color.FromArgb(FadeState, Color.Black));
                if (FadeState == 255)
                {
                    Particle.ClearParticles();
                    Particle.AddControlPoints(Settings.Default.ParticleControlCount);
                    Particle.AddParticles(Settings.Default.ParticleCount);
                    FadeState = 0;
                    FadeTimer.Start();
                }
                else
                {
                    FadeState += FADE_STEP;
                    if (FadeState > 255) FadeState = 255;
                }
            }
            XSprite.End();
            IH.Draw();
            XDevice.EndScene();
            XDevice.Present();
        }
    }
}
