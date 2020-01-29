using System;
using System.Collections.Generic;
using System.Linq;

namespace CountryCity
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> countries = new Dictionary<string, string>
            {
                {"Россия", "Москва" },
                {"Франция", "Париж" },
                {"Бельгия", "Брюссель"},
                {"Нидерланды", "Амстердам" },
                {"Германия", "Берлин" },
                {"США", "Вашингтон" }
            };

            Console.WriteLine("Угадайте Столицу!");

            do
            {
                int random = (new Random()).Next(countries.Count);
                var item = countries.ElementAt(random);

                Console.WriteLine(item.Key);
                string city = Console.ReadLine();
                //city.Equals(city, StringComparison.InvariantCultureIgnoreCase)!!!
                if (countries.ContainsValue(city))
                {
                    Console.WriteLine("ОТлично!");
                }
                else
                {
                    Console.WriteLine("Вы проиграли!");
                    break;
                }
            } while (true);
          
                
            Console.WriteLine("Hello World!");
        }
    }
}
