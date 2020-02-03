using System;
using System.Text;

namespace Polindrom
{
    class Program
    {
        static void Main(string[] args)
        {            
            StringBuilder newOutputString = new StringBuilder();
            Console.WriteLine("Введите непустую строку:");
            string inputString = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Вы ввели пустую строку :( Попробуйте ещё раз:");
                inputString = Console.ReadLine(); 
            }
            inputString = inputString.ToLower();
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                newOutputString.Append(inputString[i]);
            }
            Console.WriteLine(newOutputString);
            Console.ReadKey();
        }
    }
}
