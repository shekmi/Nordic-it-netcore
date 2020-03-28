using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork
{
    class Program1
    {
        static void Main_old2(string[] args)
        {
            Worker worker = new Worker();
            worker.OnWorkComlete += (workType, hours) =>
            {
                Console.WriteLine($"{workType} work complete in {hours} hours");
            };

            worker.OnWorkHourPassed += Worker_OnWorkHourPassed;

            worker.DoWork(3, WorkType.Work);
            worker.DoWork(2, WorkType.DoNothing);
        }

        private static void Worker_OnWorkHourPassed(WorkType workType, int totalHours, int hoursPassed)
        {
            Console.WriteLine($"{workType} Work in progress {hoursPassed} hours from {totalHours}");
        }
    }
}
