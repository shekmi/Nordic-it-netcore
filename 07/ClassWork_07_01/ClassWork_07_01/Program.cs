 using System;

namespace ClassWork_07_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Введите первое число: ");
            //float value1 = float.Parse(Console.ReadLine());
            //Console.WriteLine("Введите второе число: ");
            //float value2 = float.Parse(Console.ReadLine());

            ////value1 = MathF.Round(value1, 2);
            //Console.WriteLine(value1.ToString("0.##") + " * " + value2.ToString("0.##") + " = " + (value1 * value2).ToString("0.###"));
            //Console.WriteLine(String.Format("{0:0.##} + {1:0.##} = {2:0.##}", value1, value2, (value1 + value2)));
            //Console.WriteLine($"{value1: #.##} - {value2:#.##} = {(value1 - value2):#.##}");

            //Console.WriteLine("Hello World!");

            int []array = new int[10];

            string output;
            Console.WriteLine("Введите строку: ");
            string str = Console.ReadLine();
            Console.WriteLine("Введите подстроку для поиска: ");
            string strSearch = Console.ReadLine();

            //int index = str.IndexOf(strSearch, StringComparison.InvariantCultureIgnoreCase);
            int index1 = 0;
            do
            {
                index1 = str.IndexOf(strSearch, index1);
                if (index1 != -1)
                {                    
                    Console.WriteLine(index1);
                    index1++;
                }               
            } while (index1 >= 0);

            

           // Console.WriteLine(output = index >= 0 ? index.ToString(): "Искомая строка не найдена");

           // Console.WriteLine(str.Equals(strSearch, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
