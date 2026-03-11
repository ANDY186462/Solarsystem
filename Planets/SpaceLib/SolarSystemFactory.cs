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

            List<Planet> planets = new List<Planet>()
            {
                mercury, venus, earth, mars,
                jupiter, saturn, uranus, neptune
            };

            return planets;
        }
    }
}