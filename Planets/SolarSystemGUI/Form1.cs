using System.Drawing.Drawing2D;
using System.Linq;
using SpaceLib;
namespace SolarSystemGUI
{
    public partial class Form1 : Form
    {

        Dictionary<Planet, RectangleF> planetHitboxes = new Dictionary<Planet, RectangleF>();

        Star theSun = new Star("The sun", 696340, 609.12, 0, 0, ConsoleColor.Yellow);
        Planet earth = new Planet("Earth", 6371, 24, 149.6, 365.25, ConsoleColor.Blue);
        Planet mercury = new Planet("Mercury", 2439.7, 1407.6, 57.9, 88, ConsoleColor.Gray);
        Planet venus = new Planet("Venus", 6051.8, -5832.5, 108.2, 224.7, ConsoleColor.Yellow);
        Planet mars = new Planet("Mars", 3389.5, 24.6, 227.9, 687, ConsoleColor.Red);
        Planet jupiter = new Planet("Jupiter", 69911, 9.9, 778.5, 4333, ConsoleColor.DarkYellow);
        Planet saturn = new Planet("Saturn", 58232, 10.7, 1434, 10759, ConsoleColor.Yellow);
        Planet uranus = new Planet("Uranus", 25362, -17.2, 2871, 30687, ConsoleColor.Cyan);
        Planet neptune = new Planet("Neptune", 24622, 16.1, 4495, 60190, ConsoleColor.Blue);


        List<Planet> planets = SolarSystemFactory.CreatePlanets();

        Simulation engine = new Simulation();

        double time = 0;

        bool showLabels = true;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            this.MouseClick += Form1_MouseClick;
            planets = SolarSystemFactory.CreatePlanets();

            engine.DoTick += UpdateSimulation;
            engine.Start();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var pair in planetHitboxes)
            {
                Planet planet = pair.Key;
                RectangleF rect = pair.Value;
                if (planet == null) continue;
                if (rect.Contains(e.Location))
                {
                    PlanetGUI.Form1 gui = new PlanetGUI.Form1(planet);
                    gui.Show();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void UpdateSimulation(double newTime)
        {
            time = newTime;

            Invalidate();

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            planetHitboxes.Clear();
            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            float centerX = this.ClientSize.Width / 2;
            float centerY = this.ClientSize.Height / 2;

            float sunSize = 150;
            float minOrbitRadius = sunSize / 2 + 20;

            g.FillEllipse(Brushes.Yellow, centerX - sunSize / 2, centerY - sunSize / 2, sunSize, sunSize);

            Font labelFont = new Font("Arial", 10);
            g.DrawString(theSun.Name, labelFont, Brushes.White, centerX + sunSize / 2 + 5, centerY - 10);

            double maxOrbitalRadius = neptune.OrbitalRadius;
            double maxPlanetRadius = jupiter.ObjectRadius;
            float maxDisplayRadius = Math.Min(centerX, centerY) - 50;
            float availableRadius = maxDisplayRadius - minOrbitRadius;

            double distanceExponent = 0.4;
            float prevOrbitRadius = 0f;
            float prevPlanetSize = 0f;

            foreach (Planet planet in planets)
            {
                var (x, y, angle) = planet.CalculatePos(time);

                Brush brush = Brushes.White;

                float minPlanetSize = 20f;
                float maxPlanetSize = 80f;

                float planetSize = (float)((planet.ObjectRadius / maxPlanetRadius) * maxPlanetSize);
                if (planetSize < minPlanetSize)
                {
                    planetSize = minPlanetSize;
                }

                float orbitRadius = minOrbitRadius + (float)(Math.Pow(planet.OrbitalRadius / maxOrbitalRadius, distanceExponent) * availableRadius);

                float requiredGap = (prevPlanetSize / 2f) + (planetSize / 2f) + 10f;
                if (orbitRadius < prevOrbitRadius + requiredGap)
                {
                    orbitRadius = prevOrbitRadius + requiredGap;
                }

                prevOrbitRadius = orbitRadius;
                prevPlanetSize = planetSize;
                if (ShowIcon) { 
                g.DrawEllipse(Pens.White, centerX - orbitRadius, centerY - orbitRadius, orbitRadius * 2, orbitRadius * 2);


            }
                double angleRadians = Math.Atan2(y, x);

                float planetX = centerX + (float)(orbitRadius * Math.Cos(angleRadians));
                float planetY = centerY + (float)(orbitRadius * (Math.Sin(angleRadians)));

                RectangleF hitbox = new RectangleF(
                planetX - planetSize / 2,
                planetY - planetSize / 2,
                planetSize,
                planetSize
                );

                planetHitboxes[planet] = hitbox;

                switch (planet.Name)
                {

                    case "Mercury": brush = Brushes.Gray; break;
                    case "Venus": brush = Brushes.Goldenrod; break;
                    case "Earth": brush = Brushes.Blue; break;
                    case "Mars": brush = Brushes.Red; break;
                    case "Jupiter": brush = Brushes.Orange; break;
                    case "Saturn": brush = Brushes.Yellow; break;
                    case "Uranus": brush = Brushes.Cyan; break;
                    case "Neptune": brush = Brushes.Blue; break;
                }

                if (planet.Name == "Saturn")
                {
                    float outerRingWidth = planetSize * 2.4f;
                    float outerRingHeight = planetSize * 0.9f;

                    float innerRingWidth = planetSize * 1.6f;
                    float innerRingHeight = planetSize * 0.45f;

                    float ringAngle = (float)(time * 0.1);

                    GraphicsState state = g.Save();

                    g.TranslateTransform(planetX, planetY);
                    g.RotateTransform(ringAngle);

                    using (Pen outerPen = new Pen(Color.LightGoldenrodYellow, 3))
                    using (Pen innerPen = new Pen(Color.Khaki, 2))
                    {
                        g.DrawArc(
                            outerPen,
                            -outerRingWidth / 2,
                            -outerRingHeight / 2,
                            outerRingWidth,
                            outerRingHeight,
                            180,
                            180
                        );

                        g.DrawArc(
                            innerPen,
                            -innerRingWidth / 2,
                            -innerRingHeight / 2,
                            innerRingWidth,
                            innerRingHeight,
                            180,
                            180
                        );
                    }

                    g.Restore(state);

                    g.FillEllipse(
                        brush,
                        planetX - planetSize / 2,
                        planetY - planetSize / 2,
                        planetSize,
                        planetSize
                    );

                    state = g.Save();

                    g.TranslateTransform(planetX, planetY);
                    g.RotateTransform(ringAngle);

                    using (Pen outerPen = new Pen(Color.LightGoldenrodYellow, 3))
                    using (Pen innerPen = new Pen(Color.Khaki, 2))
                    {
                        g.DrawArc(
                            outerPen,
                            -outerRingWidth / 2,
                            -outerRingHeight / 2,
                            outerRingWidth,
                            outerRingHeight,
                            0,
                            180
                        );

                        g.DrawArc(
                            innerPen,
                            -innerRingWidth / 2,
                            -innerRingHeight / 2,
                            innerRingWidth,
                            innerRingHeight,
                            0,
                            180
                        );
                    }

                    g.Restore(state);
                }
                else
                {
                    g.FillEllipse(brush, planetX - planetSize / 2, planetY - planetSize / 2, planetSize, planetSize);
                }

                g.FillEllipse(brush, planetX - planetSize / 2, planetY - planetSize / 2, planetSize, planetSize);

                Brush textBrush = Brushes.White;

                if (showLabels)
                {
                    g.DrawString(planet.Name, labelFont, textBrush, planetX + planetSize / 2 + 4, planetY - planetSize / 2);

                }

				Font infoFont = new Font("Arial", 11);
				// Info panel
				float textX = 20;
				float textY = 20;
				g.DrawString("Up/Down = speed    I = Hide orbits    L = Hide planet labeles"   , infoFont, textBrush, textX, textY + 20);


			}
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
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
            if(e.KeyCode == Keys.I)
            {
                ShowIcon = !ShowIcon;
                Invalidate();
            }
        }

    }
}
