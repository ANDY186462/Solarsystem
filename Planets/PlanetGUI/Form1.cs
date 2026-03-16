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
        private Moon moon;

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
            g.DrawString("Esc = close   L = toggle moon labels", infoFont, textBrush, textX, textY + 190);
			g.DrawString("Up/Down = speed    I = Hide orbits", infoFont, textBrush, textX, textY + 220);

			// Draw moons
			if (selectedPlanet.Moons.Count > 0)
            {
                double maxMoonOrbit = selectedPlanet.Moons.Max(m => Math.Abs(m.OrbitalRadius));
                double maxMoonRadius = selectedPlanet.Moons.Max(m => m.ObjectRadius);

                float minMoonOrbitRadius = planetSize / 2 + 35f;
                float maxMoonOrbitRadius = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 2f - 40f;
                float availableOrbitSpace = maxMoonOrbitRadius - minMoonOrbitRadius;

                double orbitExponent = 0.45;

                float prevOrbitRadius = 0f;
                float prevMoonSize = 0f;

                foreach (Moon moon in selectedPlanet.Moons.OrderBy(m => Math.Abs(m.OrbitalRadius)))
                {
                    float minMoonSize = 8f;
                    float maxMoonSize = 20f;

                    float moonSize = (float)((moon.ObjectRadius / maxMoonRadius) * maxMoonSize);
                    if (moonSize < minMoonSize)
                    {
                        moonSize = minMoonSize;
                    }

                    float moonOrbitRadius = minMoonOrbitRadius;

                    if (maxMoonOrbit > 0)
                    {
                        moonOrbitRadius += (float)(
                            Math.Pow(Math.Abs(moon.OrbitalRadius) / maxMoonOrbit, orbitExponent) * availableOrbitSpace
                        );
                    }

                    float requiredGap = (prevMoonSize / 2f) + (moonSize / 2f) + 10f;
                    if (moonOrbitRadius < prevOrbitRadius + requiredGap)
                    {
                        moonOrbitRadius = prevOrbitRadius + requiredGap;
                    }

                    prevOrbitRadius = moonOrbitRadius;
                    prevMoonSize = moonSize;
                    if (ShowIcon)
                    {
                        g.DrawEllipse(
                            Pens.White,
                            centerX - moonOrbitRadius,
                            centerY - moonOrbitRadius,
                            moonOrbitRadius * 2,
                            moonOrbitRadius * 2
                        );
                    }
                    double angle = (2 * Math.PI / moon.OrbitalPeriod/100) * time; 

					float moonX = centerX + (float)(moonOrbitRadius * Math.Cos(angle));
                    float moonY = centerY + (float)(moonOrbitRadius * Math.Sin(angle));

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
			if (e.KeyCode == Keys.I)
			{
				ShowIcon = !ShowIcon;
				Invalidate();
			}
		}
        

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            engine.Stop();
            base.OnFormClosed(e);
        }
    }
}