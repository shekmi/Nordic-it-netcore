using Calculator.Figure;
using Calculator.Operation;
using System;

namespace ClassWork
{
	class Program
	{
		static void Main(string[] args)
		{
			Circle circle = new Circle(2);
			double perimetrCircle = circle.Calculate(CircleOperation.GetPerimetr);
			Console.WriteLine(perimetrCircle);

			Square Square = new Square(2);
			double perimetSquare = circle.Calculate(SquareOperation.GetPerimetr);
			Console.WriteLine(perimetSquare);
		}

		
	}
}
