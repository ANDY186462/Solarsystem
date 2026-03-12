using SpaceLib;

namespace PlanetGUI
{
    public partial class Form1 : Form
    {
        private Planet selectedPlanet;

        public Form1(Planet planet)
        {
            InitializeComponent();
            selectedPlanet = planet;
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.Clear(Color.Black);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            float centerX = this.ClientSize.Width / 2f;
            float centerY = this.ClientSize.Height / 2f;

            float planetSize = 120f;

            Brush planetBrush = Brushes.White;

            switch (selectedPlanet.Name)
            {
                case "Mercury": planetBrush = Brushes.Gray; break;
                case "Venus": planetBrush = Brushes.Goldenrod; break;
                case "Earth": planetBrush = Brushes.Blue; break;
                case "Mars": planetBrush = Brushes.Red; break;
                case "Jupiter": planetBrush = Brushes.Orange; break;
                case "Saturn": planetBrush = Brushes.Yellow; break;
                case "Uranus": planetBrush = Brushes.Cyan; break;
                case "Neptune": planetBrush = Brushes.Blue; break;
            }

            g.FillEllipse(
                planetBrush,
                centerX - planetSize / 2,
                centerY - planetSize / 2,
                planetSize,
                planetSize
            );

            Font font = new Font("Arial", 12);
            Brush textBrush = Brushes.White;

            float textX = 20;
            float textY = 20;

            g.DrawString($"Name: {selectedPlanet.Name}", font, textBrush, textX, textY);
            g.DrawString($"Radius: {selectedPlanet.ObjectRadius}", font, textBrush, textX, textY + 30);
            g.DrawString($"Orbital radius: {selectedPlanet.OrbitalRadius}", font, textBrush, textX, textY + 60);
            g.DrawString($"Orbital period: {selectedPlanet.OrbitalPeriod}", font, textBrush, textX, textY + 90);
            g.DrawString($"Rotational period: {selectedPlanet.RotationalPeriod}", font, textBrush, textX, textY + 120);
            g.DrawString($"Moons: {selectedPlanet.Moons.Count}", font, textBrush, textX, textY + 150);
        }
    }
}