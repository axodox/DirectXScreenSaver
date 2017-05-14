using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using DirectXScreenSaver.Properties;

namespace DirectXScreenSaver
{
    class Particle
    {
        static int MAX_START_VELOCITY = Settings.Default.ParticleStartVelocity;
        static int PARTICLE_SIZE = Settings.Default.ParticleSize;
        static double MAX_ACC = (double)Settings.Default.ParticleMaxAccelration / (double)10;
        static double GRAVITY = Settings.Default.ParticleGravity;
        static int CLIP = Settings.Default.ParticleClipSize;
        static int COLORS = Settings.Default.ParticleColors;
        static int CONTROL_MOVE_INTERVAL = Settings.Default.ParticleControlMoveInterval;
        static int CONTROL_MAX_STEP = Settings.Default.ParticleControlMoveMaxStep;

        static List<Vector2> ControlPoints;
        static List<Particle> Particles;
        static int Colors;
        static Device XDevice;
        static Sprite XSprite;
        static Random XRandom;
        static Timer ControlTimer;
        public static void AddParticles(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Particles.Add(new Particle(new Vector2(XRandom.Next(XDevice.DisplayMode.Width), XRandom.Next(XDevice.DisplayMode.Height)), new Vector2((float)(XRandom.NextDouble() * MAX_START_VELOCITY), (float)(XRandom.NextDouble() * MAX_START_VELOCITY))));
            }
        }
        public static void AddControlPoints(int count)
        {
            for (int i = 0; i < count; i++)
            {
                ControlPoints.Add(new Vector2(XRandom.Next(XDevice.DisplayMode.Width), XRandom.Next(XDevice.DisplayMode.Height)));
            }
        }
        public static void Init(Device device)
        {
            XDevice = device;
            XSprite = new Sprite(XDevice);
            XRandom = new Random();

            ControlTimer = new Timer();
            ControlTimer.Interval = CONTROL_MOVE_INTERVAL;
            ControlTimer.Tick += new EventHandler(ControlTimer_Tick);
            ControlTimer.Start();

            ControlPoints = new List<Vector2>();
            Particles = new List<Particle>();
        }
        public static void ClearParticles()
        {
            foreach (Particle P in Particles)
            {
                P.Texture.Dispose();
            }
            Particles.Clear();
            ControlPoints.Clear();
            Colors = 0;
        }

        static void ControlTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ControlPoints.Count - 1; i++)
            {
                Vector2 CP = ControlPoints[i];
                CP += new Vector2(XRandom.Next(-CONTROL_MAX_STEP, CONTROL_MAX_STEP), XRandom.Next(-CONTROL_MAX_STEP, CONTROL_MAX_STEP));
                if (CP.X < 0) CP.X = 0;
                if (CP.Y < 0) CP.Y = 0;
                if (CP.X > XDevice.DisplayMode.Width) CP.X = XDevice.DisplayMode.Width;
                if (CP.Y > XDevice.DisplayMode.Height) CP.Y = XDevice.DisplayMode.Height;
                ControlPoints[i] = CP;
            }
        }

        public static void DrawParticles()
        {
            double acc, accAngle;
            Vector2 diff;
            foreach (Vector2 CP in ControlPoints)
            {
                foreach (Particle P in Particles)
                {
                    diff = CP - P.Position;

                    acc = GRAVITY / (Math.Pow(diff.X, 2) + Math.Pow(diff.Y, 2));
                    if (acc > MAX_ACC) acc = MAX_ACC;

                    accAngle = Math.Atan(diff.Y / diff.X);
                    if (double.IsNaN(accAngle)) accAngle = 0;
                    if (diff.X < 0) accAngle += Math.PI;

                    P.Velocity.X += (float)(Math.Cos(accAngle) * acc);
                    P.Velocity.Y += (float)(Math.Sin(accAngle) * acc);
                }
            }

            float clipX1 = -CLIP;
            float clipY1 = -CLIP;
            float clipX2 = XDevice.DisplayMode.Width + CLIP;
            float clipY2 = XDevice.DisplayMode.Height + CLIP;
            XSprite.Begin(SpriteFlags.AlphaBlend);
            foreach (Particle P in Particles)
            {
                P.Position += P.Velocity;

                XSprite.Draw2D(P.Texture, PointF.Empty, 0, new PointF(P.Position.X, P.Position.Y), Color.White);
                if (P.Position.X < clipX1) P.Position.X = clipX1;
                if (P.Position.Y < clipY1) P.Position.Y = clipY1;
                if (P.Position.X > clipX2) P.Position.X = clipX2;
                if (P.Position.Y > clipY2) P.Position.Y = clipY2;
            }
            XSprite.End();
        }

        Vector2 Position;
        Vector2 Velocity;
        Texture Texture;
        Particle(Vector2 position, Vector2 velocity)
        {
            this.Position = position;
            this.Velocity = velocity;
            if (Colors < COLORS)
            {
                Colors++;
                Bitmap B = DrawPlasmaParticleTexture(PARTICLE_SIZE, ColorFromHSV(XRandom.NextDouble() * 360, 1, 0.5), Color.FromArgb(0));
                Texture = new Texture(XDevice, B, Usage.None, Pool.Managed);
                B.Dispose();
            }
            else
            {
                Texture = Particles[Particles.Count % COLORS].Texture;
            }
        }

        #region Extensions
        Bitmap DrawPlasmaParticleTexture(int d, Color In, Color Out)
        {
            Bitmap B = new Bitmap(d, d);
            Graphics G = Graphics.FromImage(B);
            GraphicsPath GP = new GraphicsPath();
            GP.AddEllipse(0, 0, d, d);
            PathGradientBrush PGB = new PathGradientBrush(GP);
            PGB.CenterColor = In;
            PGB.SurroundColors = new Color[] { Out };
            G.FillPath(PGB, GP);
            PGB.Dispose();
            GP.Dispose();
            G.Dispose();
            return B;
        }

        /// <summary>
        /// Converts the HSV colorspace to RGB
        /// </summary>
        /// <param name="hue">Selects the color, 0..360</param>
        /// <param name="saturation">Selects saturation, 0..1</param>
        /// <param name="value">Selects brightness, 0..1</param>
        /// <returns></returns>
        Color ColorFromHSV(double hue, double saturation, double value)
        {
            double angle = (hue - 150) * Math.PI / 180;
            double Ur = value * 255;
            double radius = Ur * Math.Tan(saturation * Math.Atan(Math.Sqrt(6)));
            double Vr = radius * Math.Cos(angle) / Math.Sqrt(2);
            double Wr = radius * Math.Sin(angle) / Math.Sqrt(6);

            double red = Ur - Vr - Wr;
            double green = Ur + Vr - Wr;
            double blue = Ur + 2 * Wr;

            double Rdim;
            if (red < 0)
            {
                Rdim = Ur / (Vr + Wr);
                red = 0;
                green = Ur + (Vr - Wr) * Rdim;
                blue = Ur + 2 * Wr * Rdim;
                goto Check255;
            }
            if (green < 0)
            {
                Rdim = -Ur / (Vr - Wr);
                red = Ur - (Vr + Wr) * Rdim;
                green = 0;
                blue = Ur + 2 * Wr * Rdim;
                goto Check255;
            }
            if (blue < 0)
            {
                Rdim = -Ur / (Wr * 2);
                red = Ur - (Vr + Wr) * Rdim;
                green = Ur + (Vr - Wr) * Rdim;
                blue = 0;
                goto Check255;
            }

        Check255:
            if (red > 255)
            {
                Rdim = (Ur - 255) / (Vr + Wr);
                red = 255;
                green = Ur + (Vr - Wr) * Rdim;
                blue = Ur + 2 * Wr * Rdim;
            }
            if (green > 255)
            {
                Rdim = (255 - Ur) / (Vr - Wr);
                red = Ur - (Vr + Wr) * Rdim;
                green = 255;
                blue = Ur + 2 * Wr * Rdim;
            }
            if (blue > 255)
            {
                Rdim = (255 - Ur) / (2 * Wr);
                red = Ur - (Vr + Wr) * Rdim;
                green = Ur + (Vr - Wr) * Rdim;
                blue = 255;
            }

            return Color.FromArgb(Convert.ToByte(red), Convert.ToByte(green), Convert.ToByte(blue));
        }
        #endregion
    }
}