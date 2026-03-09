using SpaceLib;
namespace SolarSystemGUI
{
    public partial class Form1 : Form
    {
        Star theSun = new Star("The sun", 696340, 609.12, 0, 0, ConsoleColor.Yellow);
        Planet earth = new Planet("Earth", 6371, 24, 149.6, 365.25, ConsoleColor.Blue);

        List<Planet> planets = new List<Planet>();

        double time = 0;

        public Form1()
        {
            InitializeComponent();
            this.ResizeRedraw = true;

            planets.Add(earth);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            float centerX = this.ClientSize.Width / 2;
            float centerY = this.ClientSize.Height / 2;

            float sunSize = 40;

            var (x, y, angle) = earth.CalculatePos(time);

            double scale = 2;

            float orbitRadius = (float)(earth.OrbitalRadius * scale);
            g.DrawEllipse(Pens.Gray, centerX - orbitRadius, centerY - orbitRadius, orbitRadius * 2, orbitRadius * 2);

            float earthX = centerX + (int)(x * scale);
            float earthY = centerY + (int)(y * scale);

            float earthSize = 10;

            g.FillEllipse(Brushes.Yellow, centerX - sunSize / 2, centerY - sunSize / 2, sunSize, sunSize);
            g.FillEllipse(Brushes.Blue, earthX - earthSize / 2, earthY - earthSize / 2, earthSize, earthSize);
        }
    }
}
