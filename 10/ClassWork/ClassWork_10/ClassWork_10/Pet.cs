using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork_10
{
    public enum AnimalKind
    {
        Mouse,
        Cat,
        Dog
    }
    class Pet
    {
        string _bithPlace;
        char _sex;
        public string Name;
        public AnimalKind Kind;
        public char Sex 
        {
            get { return _sex; }
            set 
            {
                if(value == 'M' || value == 'F'
                    || value == 'm' || value == 'f')
                {
                    _sex = char.ToUpper(value);
                }
                else
                {
                    throw new Exception();
                }
            } 
        }
        public int Age { get; set; }

        public string PetDescription
        {
            get
            {
                return $"{Name} is a {Kind} ({Sex}) of {Age} years old, bith place {_bithPlace}.";
            }
        }

        public void SetBirthPlace(string birthPlace)
        {
            _bithPlace = birthPlace;
        }
    }
}
