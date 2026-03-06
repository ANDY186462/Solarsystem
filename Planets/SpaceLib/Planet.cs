using System;
using System.Collections.Generic;
using System.Text;


namespace SpaceLib
{
	public class Planet : SpaceObject
	{
		public Planet(string name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, ConsoleColor color)
			: base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, color) { }

		public override void Draw()
		{
			Console.Write("Planet: ");
			base.Draw();
		}
	}
}