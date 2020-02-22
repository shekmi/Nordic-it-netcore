using System;
using System.Collections.Generic;
using System.Linq;

namespace ClassWork_15
{
	class Program
	{
		delegate int PerFormCalculation(int x, int y);
		delegate int PerFormCalculationArray(params int [] array );
		static void Main(string[] args)
		{
			int a = 12;
			int b = 6;			

			Console.WriteLine(Calculate.Divide<int>(a, b));

			dynamic d = new int[3];
			Console.WriteLine(d.Length);

			var account1 = new Account<int>(12, "Pavel");
			var account2 = new Account<string>("1", "Nick");
			var account3 = new Account<Guid>(Guid.NewGuid(), "Masha");

			PerFormCalculation perFormCalculation;

			perFormCalculation = Math.Max;
			int result = perFormCalculation(-1, 1);
			Console.WriteLine($"{nameof(result)} : {result}");

			int[] array = new[] { 12, 2, -4, 10, 54 };
			int sum = 0;
			foreach (var i in array)
			{
				sum += i;
			}
			Console.WriteLine($"{nameof(sum)} : {sum}");
			PerFormCalculationArray perFormCalculationArray;
			perFormCalculationArray = Min;
			Console.WriteLine(perFormCalculationArray(array));
			perFormCalculationArray = Enumerable.Max;
			Console.WriteLine(perFormCalculationArray(array));

			Func<int[], int> perFormCalculationArray = Min;
		}
		 
		static int Min(int []array)
		{
			int temp = array[0];
			foreach (var i in array)
			{
				if(temp > i)
				{
					temp = i;
				}
			}
			return temp;
		}
	}
}
