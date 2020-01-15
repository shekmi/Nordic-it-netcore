using System;


namespace ClassWork
{
    class Program
    {
        [Flags]
        enum Seasons
        {
            Winter = 3,
            Spring = 6,
            Summer = 9,
            Autumn = 12
        };

        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //Day day1 = Day.Friday;
            //Day day2 = (Day)Enum.Parse(typeof(Day), input);

            //if(day1 == day2)
            //{
            //    Console.WriteLine("You win!");
            //}
            //else
            //{
            //    Console.WriteLine("Looser!");
            //}

            //int a = 18;
            //int b = a++;

            //Console.WriteLine(a == b);
            //Console.WriteLine(a != b);
            //Console.WriteLine(a < b);
            //Console.WriteLine(a > b);
            //Console.WriteLine(a >= b);
            //Console.WriteLine(a <= b);

            //Console.WriteLine("Введите длину основания a: ");
            //double a = Double.Parse(Console.ReadLine());
            //Console.WriteLine("Введите высоту пирамиды h: ");
            //double h = Double.Parse(Console.ReadLine());
            //Console.WriteLine("Введите количество граней n: ");
            //double n = Double.Parse(Console.ReadLine());

            //double temp = 2 * Math.Tan(Math.PI / n);

            //double sPoln = (n * a) / 2 * (a / temp + Math.Sqrt(Math.Pow(h, 2) + Math.Pow((a / temp), 2)));
            //double sBok = ((n * a) / 2) * Math.Sqrt((h * h) + Math.Pow((a/temp), 2));
            //double V = h * n * (a * a) / (12 * Math.Tan(Math.PI / n));

            //Console.WriteLine("sPoln = "+ sPoln);
            //Console.WriteLine("sBok = "+ sBok);
            //Console.WriteLine("V = "+ V);

            byte a = 0b00001010;
            byte b = 0b00001100;

            Console.WriteLine(Convert.ToString(a & b, 2));
            Console.WriteLine(Convert.ToString(a & b));
            Console.WriteLine();
            Console.WriteLine(Convert.ToString(a | b, 2));
            Console.WriteLine(Convert.ToString(a | b));
            Console.WriteLine();
            Console.WriteLine(Convert.ToString(a ^ b, 2));
            Console.WriteLine(Convert.ToString(a ^ b));
            Console.WriteLine();

            Class1 classOne = new Class1();
            classOne.TryParse();
        }
    }
}
 