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
            Console.WriteLine("Введите строку из нескольких слов: ");
            while (true)
            {
                inputStr = Console.ReadLine();
                arrayStr = inputStr.Split(new char[] { ' ', '.', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (arrayStr.Length > 1)
                {
                    break;
                }
                Console.WriteLine("Слишком мало слов :( Попробуйте ещё раз: ");
            }

            for (int i = 0; i < arrayStr.Length; i++)
            {
                if (arrayStr[i].StartsWith("А", StringComparison.OrdinalIgnoreCase))
                {
                    indexFirstCharacter++;
                }
            }
            Console.WriteLine("Количество слов, начинающихся с буквы 'А': " + indexFirstCharacter);
            Console.ReadKey();
        }
    }
}
