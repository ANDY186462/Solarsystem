using System.Linq;
using SpaceLib;
namespace SolarSystemGUI
{
    public partial class Form1 : Form
    {
        Star theSun = new Star("The sun", 696340, 609.12, 0, 0, ConsoleColor.Yellow);
        Planet earth = new Planet("Earth", 6371, 24, 149.6, 365.25, ConsoleColor.Blue);
        Planet mercury = new Planet("Mercury", 2439.7, 1407.6, 57.9, 88, ConsoleColor.Gray);
        Planet venus = new Planet("Venus", 6051.8, -5832.5, 108.2, 224.7, ConsoleColor.Yellow);
        Planet mars = new Planet("Mars", 3389.5, 24.6, 227.9, 687, ConsoleColor.Red);
        Planet jupiter = new Planet("Jupiter", 69911, 9.9, 778.5, 4333, ConsoleColor.DarkYellow);
        Planet saturn = new Planet("Saturn", 58232, 10.7, 1434, 10759, ConsoleColor.Yellow);
        Planet uranus = new Planet("Uranus", 25362, -17.2, 2871, 30687, ConsoleColor.Cyan);
        Planet neptune = new Planet("Neptune", 24622, 16.1, 4495, 60190, ConsoleColor.Blue);

        List<Planet> planets = new List<Planet>();

        double time = 0;

        public Form1()
        {
            InitializeComponent();
            this.ResizeRedraw = true;

            planets.Add(earth);
            planets.Add(mercury);
            planets.Add(venus);
            planets.Add(mars);
            planets.Add(jupiter);
            planets.Add(saturn);
            planets.Add(uranus);
            planets.Add(neptune);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            float centerX = this.ClientSize.Width / 2;
            float centerY = this.ClientSize.Height / 2;

            float sunSize = 150;
            float minOrbitRadius = sunSize / 2 + 20;

            g.FillEllipse(Brushes.Yellow, centerX - sunSize / 2, centerY - sunSize / 2, sunSize, sunSize);

            double maxOrbitalRadius = neptune.OrbitalRadius;
            double maxPlanetRadius = jupiter.ObjectRadius;
            float maxDisplayRadius = Math.Min(centerX, centerY) - 50;
            float availableRadius = maxDisplayRadius - minOrbitRadius;

            double distanceExponent = 0.65;
            float prevOrbitRadius = 0f;
            float prevPlanetSize = 0f;

            List<Planet> orderedPlanets = planets.OrderBy(p => p.OrbitalRadius).ToList();

            foreach (Planet planet in orderedPlanets)
            {
                var (x, y, angle) = planet.CalculatePos(time);

                Brush brush = Brushes.White;

                float minPlanetSize = 20f;
                float maxPlanetSize = 100f;

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

                g.DrawEllipse(Pens.White, centerX - orbitRadius, centerY - orbitRadius, orbitRadius * 2, orbitRadius * 2);

                double angleRadians = Math.Atan2(y, x);

                float planetX = centerX + (float)(orbitRadius * Math.Cos(angleRadians));
                float planetY = centerY + (float)(orbitRadius * (Math.Sin(angleRadians)));

                if (planet.Color == ConsoleColor.Gray) brush = Brushes.Gray;
                else if (planet.Color == ConsoleColor.Yellow) brush = Brushes.Gold;
                else if (planet.Color == ConsoleColor.Blue) brush = Brushes.Blue;
                else if (planet.Color == ConsoleColor.Red) brush = Brushes.Red;
                else if (planet.Color == ConsoleColor.DarkYellow) brush = Brushes.Orange;
                else if (planet.Color == ConsoleColor.Cyan) brush = Brushes.Cyan;

                g.FillEllipse(brush, planetX - planetSize / 2, planetY - planetSize / 2, planetSize, planetSize);

            }
        }
    }
}
