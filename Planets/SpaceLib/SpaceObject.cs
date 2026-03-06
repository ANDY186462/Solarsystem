using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceLib
{

	public class SpaceObject
	{
		public string Name { get; protected set; }
		public double ObjectRadius { get; protected set; }       // radius av objektet
		public double RotationalPeriod { get; protected set; }  // lengde på en dag
		public double OrbitalRadius { get; protected set; }     // avstand fra sentrum
		public double OrbitalPeriod { get; protected set; }     // tid for en full runde rundt sentrum
		public ConsoleColor Color { get; protected set; }

		public SpaceObject(string name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, ConsoleColor color)
		{
			Name = name;
			ObjectRadius = objectRadius;
			RotationalPeriod = rotationalPeriod;
			OrbitalRadius = orbitalRadius;
			OrbitalPeriod = orbitalPeriod;
			Color = color;
		}

		public virtual void Draw()
		{
			Console.WriteLine($"{Name} | Radius: {ObjectRadius}, Rot. period: {RotationalPeriod}, Orb. radius: {OrbitalRadius}, Orb. period: {OrbitalPeriod}, Color: {Color}");
		}

		public virtual (double x, double y, double degrees) CalculatePos(double time)
		{
			double angle = (2 * Math.PI / OrbitalPeriod) * time;
			double degrees = angle * Math.PI / 180;

			double x = OrbitalRadius * Math.Cos(angle);
			double y = OrbitalRadius * Math.Sin(angle);

			return (x, y, degrees);
		}
	}
}

