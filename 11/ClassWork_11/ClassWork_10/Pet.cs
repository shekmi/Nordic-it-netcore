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
        public AnimalKind Kind;
        public string Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string PetDescription
        {
            get
            {
                return $"{Name} is a {Kind} ({Sex}) of {GetAge()} years old, bith place {_bithPlace}.";
            }
        }
        public string PetShortDescription
        {
            get
            {
                return $"{Name} is a {Kind}.";
            }
        }
        public char Sex
        {
            get { return _sex; }
            set
            {
                if (value == 'M' || value == 'F'
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
        public Pet() { }
        public Pet(string name, AnimalKind kind, char sex, DateTimeOffset dateOfBirth, string bithPlace )
        {
            Name = name;
            Kind = kind;
            Sex = sex;
            DateOfBirth = dateOfBirth;
            _bithPlace = bithPlace;
        }

        public void SetBirthPlace(string birthPlace)
        {
            _bithPlace = birthPlace;
        }

        public int GetAge()
        {
            var period = DateTime.Now - DateOfBirth;
            return (int)Math.Round(period.Days / 365.25);
        }

        public void WriteDescriptoin(bool IsFullDescription)
        {         
            Console.WriteLine(IsFullDescription ? PetDescription : PetShortDescription);
        }
    }
}
