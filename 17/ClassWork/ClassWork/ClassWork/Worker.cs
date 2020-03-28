using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork
{
    public class Worker
    {
        public event Action<WorkType, int> OnWorkComlete;
        public event Action<WorkType, int, int> OnWorkHourPassed;
        public void DoWork(int hours, WorkType workType)
        {
            Console.WriteLine($"{workType} Work in progress... {hours} hours");
            
            for (int i = 1; i < hours; i++)
            {
                OnWorkHourPassed?.Invoke(workType, hours, i);
            }

            //if (OnWorkComlete != null) //или так
            //{
            //    OnWorkComlete(workType, hours);
            //}
            OnWorkComlete?.Invoke(workType, hours); //или так
        }
    }
}
