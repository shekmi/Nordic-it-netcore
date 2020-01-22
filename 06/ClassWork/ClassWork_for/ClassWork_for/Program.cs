using System;

namespace ClassWork_for
{
    class Program
    {
        static void Main(string[] args)
        {
            double middleValueAll = 0;           
            double middleValueforWeek = 0;
            string outputForWeek = "The average mark for day ";
            string outputForAll = "The average mark for all the week is ";
            int numDayWeek = 1;
            int numDayAll = 0;
            var marks = new[]
            {
                new [] {2,3,3,2,3 },
                new [] { 2, 4, 5, 3},
                null,
                new [] { 5, 5, 5, 5},
                new []{4}
            };

            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] == null)
                {
                    Console.WriteLine(outputForWeek + $"#{i:0.#} is N/A");
                    continue;
                }
                for (int j = 0; j < marks[i].Length; j++)
                {
                    middleValueforWeek += marks[i][j];                    
                    numDayWeek = j;
                }
                middleValueAll += middleValueforWeek;
                middleValueforWeek = middleValueforWeek / (++numDayWeek);

                numDayAll += numDayWeek;
                Console.WriteLine(outputForWeek + "#{0} is {1:0.0}", i, middleValueforWeek);
                numDayWeek = 0;
                middleValueforWeek = 0;
            }

            middleValueAll /= numDayAll;
            Console.WriteLine(outputForAll + "{0:0.0}", middleValueAll);
        
        }
    }
}
