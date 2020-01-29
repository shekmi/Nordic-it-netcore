using System;
using System.Collections.Generic;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //Queue<string> numbers = new Queue<string>();
            //numbers.Enqueue("one");
            //numbers.Enqueue("two");
            //numbers.Enqueue("three");
            //numbers.Enqueue("four"); 
            //numbers.Enqueue("five");

            //// A queue can be enumerated without disturbing its contents. foreach (string number in numbers) { Console.WriteLine(number); }

            //while (numbers.Count > 0)
            //{
            //    string n = numbers.Dequeue(); 
            //    Console.Write($"Processing \"{n}\"... "); // here we can really do something with dequeued element :)
            //    Console.WriteLine("OK"); 
            //}

            Queue<double> numbers = new Queue<double>();
            string input;
            double result;

            while (true)
            {
                try
                {
                    input = Console.ReadLine();
                    if (input == "exit")
                    {
                        Console.WriteLine("Количество задач: " + numbers.Count);
                        break;
                    }
                    else if (input == "run")
                    {
                        while (numbers.Count > 0)
                        {
                            result = numbers.Dequeue();
                            result = Math.Sqrt(result);
                            Console.WriteLine(result);
                        }
                        continue;
                    }   
                        numbers.Enqueue(int.Parse(input));                    
                }
                catch (Exception)
                {

                    throw;
                }
                
                
            }
             
        }
    }
}
