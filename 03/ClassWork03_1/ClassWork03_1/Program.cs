using System;
using System.Text;
using System.Globalization;
using System.Threading;
using ClassWork03_1.Properties;

namespace ClassWork03_1
{
    class Program
    {
        static void Main(string[] args)
        {
			if (args != null && args.Length > 0)
			{
				Thread.CurrentThread.CurrentCulture
					= Thread.CurrentThread.CurrentUICulture
					= CultureInfo.GetCultureInfo(args[0]);
			}
			else
			{
				Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
				Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
			}

			Console.InputEncoding = Encoding.ASCII;
			Console.OutputEncoding = Encoding.Unicode;

			double d;
			Console.WriteLine(Resources.NumberPrompt);
			string input = Console.ReadLine();
			d = double.Parse(input);
			Console.WriteLine(Resources.Result + d * d);

			//int[] integerArray = new int[3];
			//integerArray[0] = 1;
			//integerArray[0] = -5;
			//integerArray[0] = 999;

			string[] names =
			{
				"Emi",
				"Bob",
				"Elsa"
			};

			string[] array = "emi, , , , bob, elsa".Split(
				separator: ", ",
				StringSplitOptions.RemoveEmptyEntries);
			Array.Resize(ref array, newSize: 10); //изменить размер массива

		}
    }
}
