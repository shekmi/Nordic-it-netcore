using System;

namespace DefinitionEvenNumber
{
    class Program
    {
        static void Main()
        {
            string output = "";
            float startContribution;
            float percent;
            float wishlullCapital;
            int numDay = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Введите сумму первоначального взноса в рублях: ");
                    startContribution = float.Parse(Console.ReadLine());
                    Console.WriteLine("Введите ежедневный процент дохода в виде десятичной дроби (1% = 0.01): ");
                    percent = float.Parse(Console.ReadLine());
                    Console.WriteLine("Введите желаемую сумму накопления в рублях: ");
                    wishlullCapital = float.Parse(Console.ReadLine());                   
                    do
                    {
                        startContribution += startContribution * percent;
                        numDay++;
                    }
                    while (wishlullCapital > startContribution);
                    output = "Необходимое количество дней для накопления желаемой суммы: " + numDay + ".";
                    break;
                }
                catch (OverflowException e)
                {
                    output = e.Message + " Попробуйте еще раз! ";
                }
                catch (FormatException e)
                {
                    output = e.Message + " Попробуйте еще раз! ";
                }
                Console.WriteLine(output);               
            }
            Console.WriteLine(output);
            Console.ReadKey();
        }            
    }
}
