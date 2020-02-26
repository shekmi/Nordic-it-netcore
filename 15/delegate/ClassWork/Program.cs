using System;

namespace ClassWork
{
	class Program
	{
		static void Main(string[] args)
		{
			Circle circle = new Circle(15.5);
			double perimetr = circle.Calculate(GetPerimetr);
		}

		static double GetPerimetr(double radius)
		{
			return 2 * Math.PI * radius * radius;
		}
	}
}
