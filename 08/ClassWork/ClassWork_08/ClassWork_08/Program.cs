using System;
using System.Collections.Generic;

namespace ClassWork_08
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> intList = new List<int>();
            //intList.Add(item:20);
            //intList.Add(item: 30);
            //intList.Add(item: 40);
            //intList.Add(item: 50);
            //intList.Add(item: 60);
            //intList.Add(item: 70);
            //intList.Add(item: 80);
            //intList.Add(item: 90);
            //Console.WriteLine(string.Join(separator: ", ", intList));

            //List<string> intString = new List<string>();
            //intString.Add(item: "one");
            //intString.Add(item: "two");
            //intString.Add(item: "three");
            //intString.Add(item: "four");
            //intString.Add(item: null);
            //intString.Add(item: null);
            //Console.WriteLine(string.Join(separator: ", ", intString));

            //List<int> newIntList = new List<int> { 90, 10, 20, 10, 40, 70 };
            ////newIntList.Remove(10);
            //newIntList.RemoveAll((int i) => i == 10);
            //newIntList.Sort();
            //Console.WriteLine(string.Join(separator: ", ", newIntList));

            List<double> doubleList = new List<double>();
            Console.WriteLine("Введите значение");
            double sum = 0;
            double midleSum = 0;
            double value = 0;
            while (true)
            {
                try
                {
                    string str = Console.ReadLine();
                    if (str.Equals("Stop", StringComparison.CurrentCultureIgnoreCase))
                    {
                        midleSum = sum / doubleList.Count;
                        Console.WriteLine("Среднее значение " + midleSum);
                        break;
                    }
                    value = double.Parse(str);
                    doubleList.Add(value);
                    sum += value;
                }
                catch(FormatException e) 
                {
                    Console.WriteLine("Ошибка");                  
                    throw;
                }
            }


        }
    }
}
