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
    }
}