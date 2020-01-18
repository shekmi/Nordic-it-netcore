using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    enum Color {Red, Green, Blue};
    class Class1Tetr
    {
        public void f()
        {
            int value;
            string output = "";
            Console.WriteLine("Введите число: ");
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out value);
            if (!result)
            {
                output = "Неверный формат";
            }
            output = value < 50 ? "Введенное число меньше 50" : "Введенное число больше либо равно 50";
            Console.WriteLine(output);
        }

        public void f1()
        {
            Color c = (Color)(new Random()).Next(0, 3);

            string output = "";
            string outputForm = "Договор аренды оформлен на период длительностью ";
            Console.WriteLine("Введите количество лет договора аренды: ");
            int years = 0;
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out years);
            if (!result)
            {
                output = "Неверный формат";
            }

            if (years <= 0 || years > 30)
            {
                output = "Вы ввели неверное значение!";
                Console.WriteLine("Вы ввели неверное значение!");
                return;
            }

            switch (years)
            {
                case 21:
                case 1:
                    output = String.Format(outputForm + "{0} год", years);
                    break;
                case 2:
                case 3:
                case 4:
                case 22:
                case 23:
                case 24:
                    output = String.Format(outputForm + "{0} годa", years);
                    break;
                default:
                    output = String.Format(outputForm + "{0} лет", years);
                    break;
            }
            Console.WriteLine(output);
        }
        public void f2()
        {
            int a, b, c;
            bool isError = false;
            try
            {
                Console.WriteLine("Введите 1 число: ");
                a = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите 2 число: ");
                b = int.Parse(Console.ReadLine());
                c = a / b;
                Console.WriteLine(c);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DivideByZeroException e)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
            catch (Exception e)
            {
                isError = true;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неизвестная ошибка");
                Console.ResetColor();
                throw;
            }
            finally //всегда выполняется!!!
            {
                if (isError)
                {
                    Console.WriteLine("finally block");
                    Environment.Exit(-1);
                }
                Environment.Exit(0);
            }
        }
    }

}
