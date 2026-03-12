using System.Drawing.Drawing2D;
using SpaceLib;

namespace PlanetGUI
{
    public partial class Form1 : Form
    {
        private Planet selectedPlanet;
        private Simulation engine = new Simulation();
        private double time = 0;
        private bool showLabels = true;

        public Form1(Planet planet)
        {
            InitializeComponent();

            selectedPlanet = planet;

            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.KeyPreview = true;
            this.BackColor = Color.Black;

            engine.DoTick += UpdateSimulation;
            engine.Start();

            this.KeyDown += Form1_KeyDown;
        }

        private void UpdateSimulation(double newTime)
        {
            time = newTime;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (selectedPlanet == null)
            {
                return;
            }

            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            float centerX = this.ClientSize.Width / 2f;
            float centerY = this.ClientSize.Height / 2f;

            float planetSize = 120f;
            Brush planetBrush = GetPlanetBrush(selectedPlanet.Name);

            // Draw selected planet in center
            g.FillEllipse(
                planetBrush,
                centerX - planetSize / 2,
                centerY - planetSize / 2,
                planetSize,
                planetSize
            );

            // Saturn rings in planet view too
            if (selectedPlanet.Name == "Saturn")
            {
                float outerRingWidth = planetSize * 2.3f;
                float outerRingHeight = planetSize * 0.8f;

                using Pen ringPen = new Pen(Color.LightGoldenrodYellow, 3);
                g.DrawEllipse(
                    ringPen,
                    centerX - outerRingWidth / 2,
                    centerY - outerRingHeight / 2,
                    outerRingWidth,
                    outerRingHeight
                );
            }

            Font infoFont = new Font("Arial", 11);
            Brush textBrush = Brushes.White;

            // Info panel
            float textX = 20;
            float textY = 20;

            g.DrawString($"Name: {selectedPlanet.Name}", infoFont, textBrush, textX, textY);
            g.DrawString($"Radius: {selectedPlanet.ObjectRadius}", infoFont, textBrush, textX, textY + 30);
            g.DrawString($"Orbital radius: {selectedPlanet.OrbitalRadius}", infoFont, textBrush, textX, textY + 60);
            g.DrawString($"Orbital period: {selectedPlanet.OrbitalPeriod}", infoFont, textBrush, textX, textY + 90);
            g.DrawString($"Rotational period: {selectedPlanet.RotationalPeriod}", infoFont, textBrush, textX, textY + 120);
            g.DrawString($"Moons: {selectedPlanet.Moons.Count}", infoFont, textBrush, textX, textY + 150);
            g.DrawString("Esc = close   L = toggle moon labels   Up/Down = speed", infoFont, textBrush, textX, textY + 190);

            // Draw moons
            if (selectedPlanet.Moons.Count > 0)
            {
                double maxMoonOrbit = selectedPlanet.Moons.Max(m => Math.Abs(m.OrbitalRadius));

                float minMoonOrbitRadius = planetSize / 2 + 35f;
                float maxMoonOrbitRadius = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 2f - 40f;
                float availableOrbitSpace = maxMoonOrbitRadius - minMoonOrbitRadius;

                double orbitExponent = 0.45;

                foreach (Moon moon in selectedPlanet.Moons)
                {
                    float moonOrbitRadius = minMoonOrbitRadius;

                    if (maxMoonOrbit > 0)
                    {
                        moonOrbitRadius += (float)(
                            Math.Pow(Math.Abs(moon.OrbitalRadius) / maxMoonOrbit, orbitExponent) * availableOrbitSpace
                        );
                    }

                    // Orbit line
                    g.DrawEllipse(
                        Pens.White,
                        centerX - moonOrbitRadius,
                        centerY - moonOrbitRadius,
                        moonOrbitRadius * 2,
                        moonOrbitRadius * 2
                    );

                    // Moon angle around selected planet
                    double angle = (2 * Math.PI / moon.OrbitalPeriod) * time;

                    float moonX = centerX + (float)(moonOrbitRadius * Math.Cos(angle));
                    float moonY = centerY + (float)(moonOrbitRadius * Math.Sin(angle));

                    float moonSize = (float)Math.Max(8, Math.Min(20, moon.ObjectRadius / 150.0));

                    g.FillEllipse(
                        Brushes.LightGray,
                        moonX - moonSize / 2,
                        moonY - moonSize / 2,
                        moonSize,
                        moonSize
                    );

                    if (showLabels)
                    {
                        g.DrawString(
                            moon.Name,
                            infoFont,
                            Brushes.White,
                            moonX + moonSize / 2 + 4,
                            moonY - moonSize / 2
                        );
                    }
                }
            }
            else
            {
                g.DrawString("This planet has no moons.", infoFont, Brushes.White, centerX - 80, centerY + 100);
            }
        }

        private Brush GetPlanetBrush(string name)
        {
            switch (name)
            {
                case "Mercury": return Brushes.Gray;
                case "Venus": return Brushes.Goldenrod;
                case "Earth": return Brushes.Blue;
                case "Mars": return Brushes.Red;
                case "Jupiter": return Brushes.Orange;
                case "Saturn": return Brushes.Yellow;
                case "Uranus": return Brushes.Cyan;
                case "Neptune": return Brushes.Blue;
                default: return Brushes.White;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.L)
            {
                showLabels = !showLabels;
                Invalidate();
            }

            if (e.KeyCode == Keys.Up)
            {
                engine.IncreaseSpeed();
            }

            if (e.KeyCode == Keys.Down)
            {
                engine.DecreaseSpeed();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            engine.Stop();
            base.OnFormClosed(e);
        }
    }
}