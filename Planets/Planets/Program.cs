using System;
using System.Collections.Generic;
using SpaceLib;

namespace SpaceSim
{
	class Astronomy
	{
		public static void Main(String[] args)
		{
			Star theSun = new Star("The sun", 696340, 609.12, 0, 0, ConsoleColor.Yellow);

			Planet mercury = new Planet("Mercury", 2439.7, 1407.6, 57.9, 88, ConsoleColor.Gray);
			Planet venus = new Planet("Venus", 6051.8, -5832.5, 108.2, 224.7, ConsoleColor.Yellow);
			Planet earth = new Planet("Earth", 6371, 24, 149.6, 365.25, ConsoleColor.Blue);
			Planet mars = new Planet("Mars", 3389.5, 24.6, 227.9, 687, ConsoleColor.Red);

			Planet jupiter = new Planet("Jupiter", 69911, 9.9, 778.5, 4333, ConsoleColor.DarkYellow);
			Planet saturn = new Planet("Saturn", 58232, 10.7, 1434, 10759, ConsoleColor.Yellow);
			Planet uranus = new Planet("Uranus", 25362, -17.2, 2871, 30687, ConsoleColor.Cyan);
			Planet neptune = new Planet("Neptune", 24622, 16.1, 4495, 60190, ConsoleColor.Blue);

			Comet halley = new Comet("Halley", 11, 52.8, 2660, 27475, ConsoleColor.White);
			Asteroid asteroid = new Asteroid("Asteroid", 262.7, 5.3, 353, 1325, ConsoleColor.DarkGray);
			AsteroidBelt asteroidBelt = new AsteroidBelt("Asteroid Belt", 0, 0, 414, 1680, ConsoleColor.DarkGray);
			DwarfPlanet pluto = new DwarfPlanet("Pluto", 1188.3, 153.3, 5906, 90560, ConsoleColor.Gray);

			//Navn, RadiusObjekt, LengdePåDag(timer), AvstandFraSentrum(km), TilForFullRundeRundtSentrum, Farge
			Moon theMoon = new Moon("The moon", 1737.4, 655.7, 0.384, 27.3, ConsoleColor.Gray, earth);

			List<SpaceObject> solarsystem = new List<SpaceObject>() { theSun, mercury, venus, earth, theMoon, mars, jupiter, saturn, uranus, neptune, pluto, halley, asteroid, asteroidBelt };


			Console.Write("Enter amount of hours: ");
			double time = double.Parse(Console.ReadLine());

			Console.Write("Enter name of spaceobject: ");
			string input = Console.ReadLine();


			if (string.IsNullOrWhiteSpace(input))
			{
				//Skrive ut alle space objekter (bortsett fra månen)
				foreach (SpaceObject obj in solarsystem)
				{
					if (obj is Star || obj is Planet || obj is Comet || obj is Asteroid || obj is AsteroidBelt || obj is DwarfPlanet)
					{
						obj.Draw();
						var (x, y, degrees) = obj.CalculatePos(time);
						Console.WriteLine($"Position at time={time}: , X={x:F2}, Y={y:F2}, Angle={degrees:F2}°");
						Console.WriteLine();
					}
					Console.ReadLine();
				}
			}
			else
			{
				{
					//Kunne skrive input med små bokstaver
					SpaceObject selectedObject = null;

					foreach (SpaceObject obj in solarsystem)
					{
						if (obj.Name.ToLower() == input.ToLower())
						{
							selectedObject = obj;
							break;
						}
					}
					if (selectedObject != null)
					{
						selectedObject.Draw();

						var (x, y, degrees) = selectedObject.CalculatePos(time);
						Console.WriteLine($"Position: X={x:F2}, Y={y:F2}, Angle={degrees:F2}");

						if (selectedObject is Planet)
						{
							Console.WriteLine("Moons: ");
						}
						//Skrive ut måner
						foreach (SpaceObject obj in solarsystem)
						{
							if (obj is Moon moon && moon.ParentPlanet == selectedObject)
							{
								moon.Draw();

								var (mx, my, mdegrees) = moon.CalculatePos(time);
								Console.WriteLine($"Position: X={mx:F2}, Y={my:F2}, Angle={mdegrees:F2}");
							}
						}
					}
					else
					{
						//Hvis det er invalid input, skriver vi ut info om solen
						Console.WriteLine("Object not found. Showing the Sun instead");
							foreach (SpaceObject obj in solarsystem)
							{
								if (obj is Star)
								{
									obj.Draw();

									var (x, y, degrees) = obj.CalculatePos(time);
									Console.WriteLine($"Position at time={time}: X={x:F2}, Y={y:F2}, Angle={degrees:F2}°");
									Console.WriteLine();
								}
							}
						}

					}

				}
			}
		}
	} 
