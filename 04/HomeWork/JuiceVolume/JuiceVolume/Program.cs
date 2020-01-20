using System;

namespace JuiceVolume
{
    class Program
    {
        [Flags]
        enum Containers
        {
            Small = 1,
            Medium = 2,
            Large = 4
        };

        static void Main()
        {
            string output = "";
            Containers containers = 0x0;
            double value = 0;
            int container20 = 20;
            int container5 = 5;
            int container1 = 1;
            int numContainer20 = 0, numContainer5 = 0;
            Console.WriteLine("Какой объем сока (в литрах) требуется упаковать ?");
            bool isNum = double.TryParse(Console.ReadLine(), out value);
            if (!isNum || value <= 0)
            {
                Console.WriteLine("Введенная строка не является числом или введено некорректное значение");
                return;
            }
            int valueToInt = (int)Math.Round(value, MidpointRounding.AwayFromZero);

            numContainer20 = valueToInt / container20;
            valueToInt %= container20;
            containers |= ((numContainer20 > 0) ? (Containers)0x4 : 0x0);

            numContainer5 = valueToInt / container5;
            valueToInt %= container5;
            containers |= ((numContainer5 > 0) ? (Containers)0x2 : 0x0);

            containers |= ((valueToInt > 0) ? (Containers)0x1 : 0x0);

            if (((int)containers & 0x4) != 0)
            {
                output = $"{container20} л : {numContainer20} шт\n";
            }
            if (((int)containers & 0x2) != 0)
            {
                output += $" {container5} л : {numContainer5} шт\n";
            }
            if (((int)containers & 0x1) != 0)
            {
                output += $" {container1} л : {valueToInt} шт\n";
            }

            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}