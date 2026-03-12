using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceLib
{
    public class MoonFactory
    {
        public static List<Moon> CreateMoons()
        {
            List<Planet> planets = SolarSystemFactory.CreatePlanets();

            Planet earth = planets.Find(p => p.Name == "Earth");
            Planet mars = planets.Find(p => p.Name == "Mars");
            Planet jupiter = planets.Find(p => p.Name == "Jupiter");
            Planet saturn = planets.Find(p => p.Name == "Saturn");
            Planet uranus = planets.Find(p => p.Name == "Uranus");
            Planet neptune = planets.Find(p => p.Name == "Neptune");

            Moon theMoon = new Moon("The moon", 1737.4, 655.7, 0.384, 27.3, ConsoleColor.Gray, earth);


            // Mars
            Moon phobos = new Moon("Phobos", 11.3, 7.7, 9, 0.32, ConsoleColor.Gray, mars);
            Moon deimos = new Moon("Deimos", 6.2, 30.3, 23, 1.26, ConsoleColor.Gray, mars);

            // Jupiter inner moons
            Moon metis = new Moon("Metis", 10, 7, 128, 0.29, ConsoleColor.Gray, jupiter);
            Moon adrastea = new Moon("Adrastea", 8, 7, 129, 0.30, ConsoleColor.Gray, jupiter);
            Moon amalthea = new Moon("Amalthea", 84, 12, 181, 0.50, ConsoleColor.Gray, jupiter);
            Moon thebe = new Moon("Thebe", 49, 12, 222, 0.67, ConsoleColor.Gray, jupiter);
            Moon io = new Moon("Io", 1821, 42, 422, 1.77, ConsoleColor.Yellow, jupiter);
            Moon europa = new Moon("Europa", 1560, 85, 671, 3.55, ConsoleColor.Gray, jupiter);
            Moon ganymede = new Moon("Ganymede", 2634, 172, 1070, 7.15, ConsoleColor.Gray, jupiter);
            Moon callisto = new Moon("Callisto", 2410, 400, 1883, 16.69, ConsoleColor.Gray, jupiter);

            // Jupiter outer moons
            Moon leda = new Moon("Leda", 8, 12, 11165, 238.72, ConsoleColor.Gray, jupiter);
            Moon himalia = new Moon("Himalia", 93, 7.8, 11480, 250.56, ConsoleColor.Gray, jupiter);
            Moon lysithea = new Moon("Lysithea", 18, 12, 11720, 259.22, ConsoleColor.Gray, jupiter);
            Moon elara = new Moon("Elara", 38, 12, 11737, 259.65, ConsoleColor.Gray, jupiter);
            Moon ananke = new Moon("Ananke", 15, 12, 21200, -631, ConsoleColor.Gray, jupiter);
            Moon carme = new Moon("Carme", 23, 12, 22600, -692, ConsoleColor.Gray, jupiter);
            Moon pasiphae = new Moon("Pasiphae", 30, 12, 23500, -735, ConsoleColor.Gray, jupiter);
            Moon sinope = new Moon("Sinope", 19, 12, 23700, -758, ConsoleColor.Gray, jupiter);

            // Saturn moons
            Moon atlas = new Moon("Atlas", 15, 12, 138, 0.60, ConsoleColor.Gray, saturn);
            Moon prometheus = new Moon("Prometheus", 43, 12, 139, 0.61, ConsoleColor.Gray, saturn);
            Moon pandora = new Moon("Pandora", 40, 12, 142, 0.63, ConsoleColor.Gray, saturn);
            Moon epimetheus = new Moon("Epimetheus", 65, 12, 151, 0.69, ConsoleColor.Gray, saturn);
            Moon janus = new Moon("Janus", 89, 12, 151, 0.69, ConsoleColor.Gray, saturn);
            Moon mimas = new Moon("Mimas", 198, 23, 186, 0.94, ConsoleColor.Gray, saturn);
            Moon enceladus = new Moon("Enceladus", 252, 33, 238, 1.37, ConsoleColor.Gray, saturn);
            Moon tethys = new Moon("Tethys", 531, 45, 295, 1.89, ConsoleColor.Gray, saturn);
            Moon telesto = new Moon("Telesto", 15, 12, 295, 1.89, ConsoleColor.Gray, saturn);
            Moon calypso = new Moon("Calypso", 13, 12, 295, 1.89, ConsoleColor.Gray, saturn);
            Moon dione = new Moon("Dione", 561, 66, 377, 2.74, ConsoleColor.Gray, saturn);
            Moon helene = new Moon("Helene", 18, 12, 377, 2.74, ConsoleColor.Gray, saturn);
            Moon rhea = new Moon("Rhea", 764, 108, 527, 4.52, ConsoleColor.Gray, saturn);
            Moon titan = new Moon("Titan", 2575, 382, 1222, 15.95, ConsoleColor.Gray, saturn);
            Moon hyperion = new Moon("Hyperion", 143, 21, 1481, 21.28, ConsoleColor.Gray, saturn);
            Moon iapetus = new Moon("Iapetus", 734, 1903, 3561, 79.33, ConsoleColor.Gray, saturn);
            Moon phoebe = new Moon("Phoebe", 107, 9.3, 12952, -550.48, ConsoleColor.Gray, saturn);

            // Uranus moons
            Moon ariel = new Moon("Ariel", 581, 60, 191, 2.52, ConsoleColor.Gray, uranus);
            Moon umbriel = new Moon("Umbriel", 585, 84, 266, 4.14, ConsoleColor.Gray, uranus);
            Moon titania = new Moon("Titania", 789, 209, 436, 8.71, ConsoleColor.Gray, uranus);
            Moon oberon = new Moon("Oberon", 761, 324, 583, 13.46, ConsoleColor.Gray, uranus);
            Moon miranda = new Moon("Miranda", 236, 34, 130, 1.41, ConsoleColor.Gray, uranus);

            // Neptune moons
            Moon triton = new Moon("Triton", 1353, 141, 355, -5.88, ConsoleColor.Gray, neptune);
            Moon nereid = new Moon("Nereid", 170, 11, 5513, 360.13, ConsoleColor.Gray, neptune);

            List<Moon> moons = new List<Moon>()
    {
    theMoon,

    phobos, deimos,

    metis, adrastea, amalthea, thebe, io, europa, ganymede, callisto,

    leda, himalia, lysithea, elara, ananke, carme, pasiphae, sinope,

    atlas, prometheus, pandora, epimetheus, janus, mimas, enceladus,
    tethys, telesto, calypso, dione, helene, rhea, titan,
    hyperion, iapetus, phoebe,

    ariel, umbriel, titania, oberon, miranda,

    triton, nereid
};
            return moons;
        }
    }
}