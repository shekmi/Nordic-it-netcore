using System;

namespace ClassWork03
{
    class Program
    {
        static void Main(string[] args)
        {
            object s = 10;
            int a = (int)s;
            a += 5;

            Console.WriteLine(a);

            dynamic d = "string";
            Console.WriteLine(d.Length);
            string str = default(string);
            Console.WriteLine($"{default(string)}");


           Console.ReadLine();

        }
    }
}
