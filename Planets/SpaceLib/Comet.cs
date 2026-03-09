using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceLib
{
    public class Comet : SpaceObject
    {
        public Comet(string name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, ConsoleColor color)
            : base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, color) { }

        public override void Draw()
        {
            Console.Write("Comet: ");
            base.Draw();
        }
    }
}
