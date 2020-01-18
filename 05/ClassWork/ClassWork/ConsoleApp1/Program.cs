using System;

namespace ConsoleApp1
{
    [Flags]
    enum DisplayOption
    {
        Binary = 1,
        Hex = 2
    };

    class Program
    {
        static void Main(string[] args)
        {
            Class1Tetr obj = new Class1Tetr();
            //obj.f();
            //obj.f1();
            obj.f2();
            string output = "";
            string outputForm = "Договор аренды оформлен на период длительностью ";
            Console.WriteLine("Введите количество лет договора аренды: ");
            int years = 0;
            int yearsOst = 0;
            string input = Console.ReadLine();
            bool result = int.TryParse(input, out years);
            if(!result)
            {
                output = "Неверный формат";
            }
            
            if(years < 1 || years > 100)
            {
                throw new Exception(message: "Введенное значение выходит за допустимые пределы от до 30!");
                output = "Вы ввели неверное значение!";
                Console.WriteLine("Вы ввели неверное значение!");
                return;
            }

            //if((years >= 2 && years <= 4) || (years >= 22 && years <= 24))
            //{
            //    output = String.Format(outputForm + "{0} годa", years);
            //}
            //else if(years == 21 || years == 1)
            //{
            //    output = String.Format(outputForm + "{0} год", years);
            //}
            //else
            //{
            //    output = String.Format(outputForm + "{0} лет", years);
            //}

            //if (years <= 1 && years >= 10|| years > 30)
            //{

            if (years > 10 && years < 15)
            {
                output = String.Format(outputForm + "{0} лет", years);
            }
            else
            {
                yearsOst = years % 10;
                if (yearsOst > 1 && yearsOst < 5)
                {
                    output = String.Format(outputForm + "{0} годa", years);
                }
                else if (yearsOst == 1)
                {
                    output = String.Format(outputForm + "{0} год", years);
                }
                else
                {
                    output = String.Format(outputForm + "{0} лет", years);
                }
            }


                Console.WriteLine(output);
        }
    }
}
