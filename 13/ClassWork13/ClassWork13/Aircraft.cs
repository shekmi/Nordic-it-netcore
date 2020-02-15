using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork13
{
    class Aircraft
    {
        protected int MaxHeight { get; private set; }

        public int CurrentHeight { get; private set; }
        
        public Aircraft(int maxHeight)
        {
            MaxHeight = maxHeight;
            CurrentHeight = 0;
        }

        public void TakeUpper(int delta)
        {
            if(delta <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if((CurrentHeight + delta) > MaxHeight)
            {
                MaxHeight = CurrentHeight;
            }
            else
            {
                CurrentHeight += delta;
            }
        }

        void TakeLower(int delta)
        {
            if (delta <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if ((CurrentHeight - delta) > 0)
            {
                CurrentHeight -= delta;
            }
            else if((CurrentHeight - delta) == 0)
            {
                CurrentHeight = 0;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void WriteAllProperties()
        {
            Console.WriteLine(
                $"CurrentHeight: {CurrentHeight}\n" +
                $"MaxHeight: {MaxHeight}");
        }
    }
}
