using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator.Operation
{
	public static class CircleOperation
	{
		public static double GetPerimetr(double radius)
		{
			return 2 * Math.PI * radius * radius;
		}
	}
}
