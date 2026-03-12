using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SpaceLib
{
	public class MoonFactory
	{
		public PointF Position;
		public PointF Velocity;
		public float Size;
		public float Life;

		public MoonFactory(PointF position, PointF velocity, float size, float life)
		{
			Position = position;
			Velocity = velocity;
			Size = size;
			Life = life;
		}

		public void Update(float deltaTime)
		{
			Position = new PointF(Position.X + Velocity.X * deltaTime, Position.Y + Velocity.Y * deltaTime);
			Life -= deltaTime;
		}

		public bool IsAlive => Life > 0;
	}
}