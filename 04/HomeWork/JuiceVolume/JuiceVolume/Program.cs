using System;

namespace JuiceVolume
{
    class Program
    {
        [Flags]
        enum Containers
        {
            Empty = 0,
            Small = 1,
            Medium = 2,
            Large = 4
        };

        static void Main()
        {
            string output = "";
            Containers containers = Containers.Empty;
            double value = 0;
            const int containerL = 20;
            const int containerM = 5;
            const int containerS = 1;
            int numContainerL = 0, numContainerM = 0;
            try
            {
                Console.WriteLine("Какой объем сока (в литрах) требуется упаковать ?");
                bool isNum = double.TryParse(Console.ReadLine(), out value);
                if (!isNum || value <= 0)
                {
                    Console.WriteLine("Введенная строка не является числом или введено некорректное значение");
                    return;
                }
                int valueToInt = checked((int)Math.Round(value, MidpointRounding.AwayFromZero));

                numContainerL = valueToInt / containerL;
                valueToInt %= containerL;
                containers |= ((numContainerL > 0) ? Containers.Large : Containers.Empty);

                numContainerM = valueToInt / containerM;
                valueToInt %= containerM;
                containers |= ((numContainerM > 0) ? Containers.Medium : Containers.Empty);

                containers |= ((valueToInt > 0) ? Containers.Small : Containers.Empty);

                if ((containers & Containers.Large) != 0)
                {
                    output = $"{containerL} л : {numContainerL} шт\n";
                }
                if ((containers & Containers.Medium) != 0)
                {
                    output += $" {containerM} л : {numContainerM} шт\n";
                }
                if ((containers & Containers.Small) != 0)
                {
                    output += $" {containerS} л : {valueToInt} шт\n";
                }
                Console.WriteLine(output);             
            }
            catch(OverflowException e)
            {
                Console.WriteLine("Указанное значение слишком большое\n" +
                   e.Message);
            }
            Console.ReadKey();
        }
    }
}