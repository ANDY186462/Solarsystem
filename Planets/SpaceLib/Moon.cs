using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceLib
{
	public class Moon : SpaceObject
	{

		public Planet ParentPlanet;
		public Moon(string name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, ConsoleColor color, Planet parentPlanet)
			: base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, color) {
			
			ParentPlanet =  parentPlanet;

		}
		public override void Draw()
		{
			Console.Write("Moon: ");
			base.Draw();
		}

		public override (double x, double y, double degrees) CalculatePos(double time)
		{
			var (px, py, pdegrees) = ParentPlanet.CalculatePos(time);
			double angle = (2 * Math.PI / OrbitalPeriod) * time;
			double degrees = angle * Math.PI / 180;

			double x = px + OrbitalRadius * Math.Cos(angle);
			double y = py + OrbitalRadius * Math.Sin(angle);

			return (x, y, degrees);
		}

	}
}