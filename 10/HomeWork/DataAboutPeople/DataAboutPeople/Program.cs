using System;

namespace DataAboutPeople
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 0;
            Console.WriteLine("Enter number of people");
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Enter corect value!");
            }
            Person[] person = new Person[number];
            for (int i = 0; i < number; i++)
            {
                person[i] = new Person();
                Console.WriteLine($"Enter name {i}:");
                person[i].Name = Console.ReadLine();
                Console.WriteLine($"Enter age {i}:");
                try
                {
                    person[i].AgeNow = int.Parse(Console.ReadLine());
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(person[i].PrintOutput);
            }
            Console.ReadKey();
        }
    }
}
