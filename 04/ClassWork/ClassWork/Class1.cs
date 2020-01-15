using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork
{
    class Class1
    {
        [Flags]
        enum Days
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        };
        public void TryParse()
        {
            Days days = Days.Friday | Days.Monday;
            Days allDays = Days.Sunday | Days.Monday | Days.Tuesday | Days.Wednesday | Days.Thursday | Days.Friday | Days.Saturday;
            Days notGroup = allDays ^ days;

            int y = -1;
            y = int.Parse("bad");
            bool ok = int.TryParse("bad", out y);
            if(ok)
            {
                string str = "парс прошел";
            }
            else
            {
                string str = "ошибка, парс не прошел";
            }

        }
    }
}
