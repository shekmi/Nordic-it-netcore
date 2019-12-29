using System;
using System.Globalization;

namespace ClassWork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите радиус: ");
            string radius = Console.ReadLine();
            radius = radius.Replace(".", ",");
            double s = 2 * Math.PI * double.Parse(radius);
            Console.Write("Длина окружности = " + s.ToString());


            //Console.WriteLine();
            //int a = -10;
            //string myNumberIsText = "4.5";
            //Console.WriteLine(myNumberIsText);
            //Console.WriteLine(2 + myNumberIsText + 2);
            //float number = float.Parse(myNumberIsText, CultureInfo.InvariantCulture);
            //Console.WriteLine(number);

            Console.ReadLine();
        }
    }
}
