using System;

namespace TabPifagor
{
    class Program
    {
        static void Main(string[] args)
        {
            string output = (String.Format("{0, -3}", "*"));
            int[] Array1;
            int[] Array2;
            try
            {
                Console.WriteLine("Введите количество элементов по горинзонтали: ");
                string input = Console.ReadLine();
                int number1 = int.Parse(input);
                Console.WriteLine("Введите количество элементов по вертикали: ");
                input = Console.ReadLine();
                int number2 = int.Parse(input);
                if (number1 > 0 && number2 > 0)
                {
                    Array1 = new int[number1];
                    Array2 = new int[number2];
                    for (int i = 0; i < number1; i++)
                    {
                        Array1[i] = i + 1;
                        output += (String.Format("{0, 5}", Array1[i]));
                    }
                    output += "\n";

                    for (int i = 0; i < number2; i++)
                    {
                        Array2[i] = i + 1;
                    }

                    for (int i = 0; i < number2; i++)
                    {
                        output += String.Format("{0, -3}", Array2[i]);
                        for (int j = 0; j < number1; j++)
                        {
                            output += String.Format("{0, 5}", (Array2[i] * Array1[j]));
                        }
                        output += "\n";
                    }
                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine("Введенные значения некорректные");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
