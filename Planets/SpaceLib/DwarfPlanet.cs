using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceLib
{
	public class DwarfPlanet : SpaceObject
	{
		public DwarfPlanet(string name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, ConsoleColor color)
			: base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, color) { }

		public override void Draw()
		{
			Console.Write("Dwarf Planet : ");
			base.Draw();
		}
	}
}

	