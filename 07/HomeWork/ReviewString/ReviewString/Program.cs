using System;

namespace ReviewString
{
    class Program
    {
        static void Main(string[] args)
        {
            int indexFirstCharacter = 0;
            string inputStr = "";
            string[] arrayStr;
            while (true)
            {
                Console.WriteLine("Введите строку из нескольких слов: ");
                inputStr = Console.ReadLine();                                
                arrayStr = inputStr.Split(new char[] { ' ', '.', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (arrayStr.Length < 2)
                {
                    Console.WriteLine("Слишком мало слов :( Попробуйте ещё раз: ");
                    continue;
                }

                for (int i = 0; i < arrayStr.Length; i++)
                {
                    if (arrayStr[i].StartsWith("А", StringComparison.OrdinalIgnoreCase))
                    {
                        indexFirstCharacter++;
                    }
                }
                break;
            }
            Console.WriteLine("Количество слов, начинающихся с буквы 'А': " + indexFirstCharacter);
            Console.ReadKey();
        }
    }
}
