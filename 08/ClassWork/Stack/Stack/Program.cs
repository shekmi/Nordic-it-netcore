using System;
using System.Collections.Generic;
namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            Console.WriteLine("Введите команду (wash, dry, exit)");
            int i = 0;
            string output = "";
            while (true)
            {
                string comand = Console.ReadLine();
                if(comand == "wash")
                {
                    i++;
                    stack.Push("Plate+i");
                    output = "Количество тарелок на вытериание " + stack.Count;
                }
                else if(comand == "dry")
                {
                    if(stack.Count > 0)
                    {
                        stack.Pop();
                        output = "Количество тарелок на вытериание " + stack.Count;
                    }
                    else
                    {
                        output = "Стопка тарелок пуста";
                    }
                }
                else if(comand == "exit")
                {
                    output = "Количество тарелок на вытериание " + stack.Count;
                    break;
                }
                Console.WriteLine(output);
            }
        }
    }
}
