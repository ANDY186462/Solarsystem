using System.Collections.Generic;

namespace SpaceLib
{
    public static class SolarSystemFactory
    {
        public static List<Planet> CreatePlanets()
        {
            Planet mercury = new Planet("Mercury", 2439.7, 1407.6, 57.9, 88, ConsoleColor.Gray);
            Planet venus = new Planet("Venus", 6051.8, -5832.5, 108.2, 224.7, ConsoleColor.Yellow);
            Planet earth = new Planet("Earth", 6371, 24, 149.6, 365.25, ConsoleColor.Blue);
            Planet mars = new Planet("Mars", 3389.5, 24.6, 227.9, 687, ConsoleColor.Red);
            Planet jupiter = new Planet("Jupiter", 69911, 9.9, 778.5, 4333, ConsoleColor.DarkYellow);
            Planet saturn = new Planet("Saturn", 58232, 10.7, 1434, 10759, ConsoleColor.Yellow);
            Planet uranus = new Planet("Uranus", 25362, -17.2, 2871, 30687, ConsoleColor.Cyan);
            Planet neptune = new Planet("Neptune", 24622, 16.1, 4495, 60190, ConsoleColor.Blue);

            // Earth
            earth.AddMoon(new Moon("The moon", 1737.4, 655.7, 0.384, 27.3, ConsoleColor.Gray, earth));

            // Mars
            mars.AddMoon(new Moon("Phobos", 11.3, 7.7, 9, 0.32, ConsoleColor.Gray, mars));
            mars.AddMoon(new Moon("Deimos", 6.2, 30.3, 23, 1.26, ConsoleColor.Gray, mars));

            // Jupiter
            jupiter.AddMoon(new Moon("Metis", 10, 7, 128, 0.29, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Adrastea", 8, 7, 129, 0.30, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Amalthea", 84, 12, 181, 0.50, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Thebe", 49, 12, 222, 0.67, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Io", 1821, 42, 422, 1.77, ConsoleColor.Yellow, jupiter));
            jupiter.AddMoon(new Moon("Europa", 1560, 85, 671, 3.55, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Ganymede", 2634, 172, 1070, 7.15, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Callisto", 2410, 400, 1883, 16.69, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Leda", 8, 12, 11165, 238.72, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Himalia", 93, 7.8, 11480, 250.56, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Lysithea", 18, 12, 11720, 259.22, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Elara", 38, 12, 11737, 259.65, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Ananke", 15, 12, 21200, -631, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Carme", 23, 12, 22600, -692, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Pasiphae", 30, 12, 23500, -735, ConsoleColor.Gray, jupiter));
            jupiter.AddMoon(new Moon("Sinope", 19, 12, 23700, -758, ConsoleColor.Gray, jupiter));

            // Saturn
            saturn.AddMoon(new Moon("Atlas", 15, 12, 138, 0.60, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Prometheus", 43, 12, 139, 0.61, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Pandora", 40, 12, 142, 0.63, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Epimetheus", 65, 12, 151, 0.69, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Janus", 89, 12, 151, 0.69, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Mimas", 198, 23, 186, 0.94, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Enceladus", 252, 33, 238, 1.37, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Tethys", 531, 45, 295, 1.89, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Telesto", 15, 12, 295, 1.89, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Calypso", 13, 12, 295, 1.89, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Dione", 561, 66, 377, 2.74, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Helene", 18, 12, 377, 2.74, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Rhea", 764, 108, 527, 4.52, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Titan", 2575, 382, 1222, 15.95, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Hyperion", 143, 21, 1481, 21.28, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Iapetus", 734, 1903, 3561, 79.33, ConsoleColor.Gray, saturn));
            saturn.AddMoon(new Moon("Phoebe", 107, 9.3, 12952, -550.48, ConsoleColor.Gray, saturn));

            // Uranus
            uranus.AddMoon(new Moon("Cordelia", 50, 12, 50, 0.34, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Ophelia", 54, 12, 54, 0.38, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Bianca", 59, 12, 59, 0.43, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Cressida", 62, 12, 62, 0.46, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Desdemona", 63, 12, 63, 0.47, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Juliet", 64, 12, 64, 0.49, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Portia", 66, 12, 66, 0.51, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Rosalind", 70, 12, 70, 0.56, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Belinda", 75, 12, 75, 0.62, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Puck", 86, 12, 86, 0.76, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Miranda", 236, 34, 130, 1.41, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Ariel", 581, 60, 191, 2.52, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Umbriel", 585, 84, 266, 4.14, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Titania", 789, 209, 436, 8.71, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Oberon", 761, 324, 583, 13.46, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Caliban", 120, 12, 7169, -580.00, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Stephano", 16, 12, 7948, -674.00, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Sycorax", 75, 12, 12213, -1289.00, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Prospero", 25, 12, 16568, -2019.00, ConsoleColor.Gray, uranus));
            uranus.AddMoon(new Moon("Setebos", 24, 12, 17681, -2239.00, ConsoleColor.Gray, uranus));

            // Neptune
            neptune.AddMoon(new Moon("Triton", 1353, 141, 355, -5.88, ConsoleColor.Gray, neptune));
            neptune.AddMoon(new Moon("Nereid", 170, 11, 5513, 360.13, ConsoleColor.Gray, neptune));

            return new List<Planet>()
            {
                mercury, venus, earth, mars,
                jupiter, saturn, uranus, neptune
            };
        }
    }
}