using SpaceLib;
namespace SolarSystemGUI
{
    public partial class Form1 : Form
    {

        Star theSun = new Star("The sun", 696340, 609.12, 0, 0, ConsoleColor.Yellow);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            int sunSize = 40;

            g.FillEllipse(Brushes.Yellow, centerX - sunSize / 2, centerY - sunSize / 2, sunSize, sunSize);
        }
    }
}
