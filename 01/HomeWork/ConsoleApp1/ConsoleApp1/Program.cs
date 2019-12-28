using System;
using System.Threading;

namespace DemoApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Thread.Sleep(5000); //timeout:TimeSpan.FromDays(5)
            Console.WriteLine($"Здравствуйте, {name}!");
            Thread.Sleep(5000);
            Console.WriteLine($"Прощай, {name}!");
            Console.ReadKey();
        }
    }
}
