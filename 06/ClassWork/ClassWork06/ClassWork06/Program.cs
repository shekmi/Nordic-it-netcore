using System;

namespace ClassWork06
{
    class Program
    {
        static void Main(string[] args)
        {

            //do
            //{


            //} while (Console.ReadLine() != "Exit");

            //do
            //{
            //    string str = Console.ReadLine();
            //    if (str == "exit")
            //        continue;

            //} while (Console.ReadLine() != "Exit");



            //int temp;
            //do
            //{
            //    temp = Console.ReadLine().Length;
            //    if (temp <= 15)
            //    {
            //        Console.WriteLine($"Entered string length is {temp}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Too long string. Try another:");
            //        continue;
            //    }

            //    break;

            //} while (true);

            int number;
            int time = 5;
            int i = 0;
            while (i < 2)
            {
                Console.WriteLine("Введите число: ");
                string str = Console.ReadLine();

                bool result = int.TryParse(str, out number);
                if(!result)
                {
                    Console.WriteLine("Не число");
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(time));
                    time += 10;
                    i++;
                }
                else
                {                    
                    Console.WriteLine($"Ваше число в квадрате: {number * number}");
                }
            }
        }

 

       

    }
}
