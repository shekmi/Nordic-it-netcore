using System;
using System.Text;

namespace Polindrom
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString = "";
            StringBuilder newOutputString = new StringBuilder();
            Console.WriteLine("Введите непустую строку:");
            while (true)
            {
                inputString = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputString))
                {
                    Console.WriteLine("Вы ввели пустую строку :( Попробуйте ещё раз:");
                    continue;
                }
                inputString = inputString.ToLower();
                for (int i = inputString.Length - 1; i >= 0; i--)
                {
                    newOutputString.Append(inputString[i]);
                }
                Console.WriteLine(newOutputString);
                break;
            }
            Console.ReadKey();
        }
    }
}
