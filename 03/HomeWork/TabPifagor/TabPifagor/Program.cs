using System;

namespace TabPifagor
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputStr = (String.Format("{0, -3}", "*"));
            int[] myValueArray1;
            int[] myValueArray2;
            try
            {
                Console.WriteLine("Введите количество элементов по горинзонтали: ");               
                int quantityElemetsHor = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите количество элементов по вертикали: ");               
                int quantityElemetsVer = int.Parse(Console.ReadLine());
                if (quantityElemetsHor <= 0 && quantityElemetsVer <= 0)
                {
                    Console.WriteLine("Введенные значения некорректные");
                    return;
                }
                myValueArray1 = new int[quantityElemetsHor];
                myValueArray2 = new int[quantityElemetsVer];
                for (int i = 0; i < quantityElemetsHor; i++)
                {
                    myValueArray1[i] = i + 1;
                    outputStr += (String.Format("{0, 5}", myValueArray1[i]));
                }
                outputStr += "\n";

                for (int i = 0; i < quantityElemetsVer; i++)
                {
                    myValueArray2[i] = i + 1;
                }

                for (int i = 0; i < quantityElemetsVer; i++)
                {
                    outputStr += String.Format("{0, -3}", myValueArray2[i]);
                    for (int j = 0; j < quantityElemetsHor; j++)
                    {
                        outputStr += String.Format("{0, 5}", (myValueArray2[i] * myValueArray1[j]));
                    }
                    outputStr += "\n";
                }
                Console.WriteLine(outputStr);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
