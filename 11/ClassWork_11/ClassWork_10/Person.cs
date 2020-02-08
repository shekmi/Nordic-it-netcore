using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork_10
{
    class Person
    {
        int _age;           
        public string Name { get; set; }
        public int GetAge
        {
            get
            {
                return _age;
            }
            set
            {
                if (value > 0 && value < 105)
                {
                    _age = value;
                }
                else
                {
                    throw new Exception("Value is fault");
                }
            }
        }

        public int AgeInForYear
        {
            get
            {
                return _age + 4;
            }
        }

        public int AgeInSomeYears(int yearsToAdd)
        {
            return _age + yearsToAdd;
        }
        public string PropertiesString()
        {
            return $"Name: {Name}, age in 4 years: {AgeInSomeYears(4)}.";
        }
    }
}
