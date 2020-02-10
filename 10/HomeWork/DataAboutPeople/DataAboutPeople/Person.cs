using System;
using System.Collections.Generic;
using System.Text;

namespace DataAboutPeople
{
    class Person
    {
        int _ageNow;
        public string Name { get; set; }
        public int AgeNow
        {
            get
            {
                return _ageNow;
            }
            set
            {
                if (value > 0 && value < 105)
                {
                    _ageNow = value;
                }
                else
                {
                    throw new FormatException("Invalid value");
                }
            }
        }
        public int AgeInFourYears { get { return (_ageNow + 4); } }

        public string PrintOutput { get { return $"{Name}, age in 4 years: {AgeInFourYears}"; } }
    }
}

