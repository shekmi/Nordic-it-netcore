using System;

namespace DefinitionEvenNumber
{
    class Program
    {
        static void Main(string[] args)
        {           
            int inputValue = 0;
            int numEvenNumber = 0;
            string inputStr = "", outputStr = "";
            Console.WriteLine("Введите положительное натуральное число не более 2 миллиардов: ");
            while (true)
            {
                try
                {
                    inputStr = Console.ReadLine();
                    inputValue = int.Parse(inputStr);
                    if (inputValue < 0)
                    {
                        outputStr = "Введено неверное значение! Попробуйте ещё раз: ";
                    }
                    else
                    {
                        do 
                        {
                            if (((inputValue % 10) % 2) == 0)
                            {
                                numEvenNumber++;
                            }
                            inputValue /= 10;
                        }while(inputValue > 0);
                        break;
                    }
                }
                catch (OverflowException e)
                {
                    outputStr = e.Message + " Попробуйте еще раз: ";
                }
                catch (FormatException e)
                {
                    outputStr = e.Message + " Попробуйте еще раз: ";
                }
                Console.WriteLine(outputStr);
            }
            Console.WriteLine($"В числе {inputStr} содержится следующее количество четных цифр: {numEvenNumber}");
            Console.ReadKey();
        }
    }
}
