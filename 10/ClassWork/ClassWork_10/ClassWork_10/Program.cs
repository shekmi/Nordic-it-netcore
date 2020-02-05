using System;

namespace ClassWork_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Point point1 = new Point();
            //point1.X = 1.0F;
            //point1.Y = -1.5F;
            //point1.Color = "Red";
            //Point point2 = point1;
            //Console.WriteLine(point1.ToString());
            //Console.WriteLine(point1 == point2);
            //Console.WriteLine(point1.Equals(point2));

            //Wallet myWallet = new Wallet();
            //myWallet.DollarsAmount = 100;
            //myWallet.RublesAmount = 6289.25M;
            //myWallet.AddDollars(100);
            //Console.WriteLine(myWallet.Rubles);
            //Console.WriteLine(myWallet.GetDollars());
            Pet pet1 = new Pet
            {
                Name = "Lucky",
                Kind = AnimalKind.Cat,
                Age = 5,
                Sex = 'm',
            };
            pet1.SetBirthPlace("Moscow");
            Console.WriteLine(pet1.PetDescription);

            Pet pet2 = new Pet
            {
                Name = "Wolf",
                Kind = AnimalKind.Dog,
                Age = 7,
                Sex = 'm',
            };
            pet2.SetBirthPlace("Berlin");
            Console.WriteLine(pet2.PetDescription);
        }
    }

    class Point
    {
        public float Y;
        public float X;
        public string Color;
    }

    class Wallet
    {
        private decimal _money;
        private const decimal _rublesRatio = 1;
        private const decimal _dollarsRatio = 62.8925M;

        public decimal DollarsAmount;
        public decimal RublesAmount;

        public decimal Rubles
        {
            get { return _money / _rublesRatio; }
            set { _money = value * _rublesRatio; }
        }

        public decimal GetDollars()
        {
            return _money / _dollarsRatio;
        }

        public void AddDollars(decimal dollarsTOAdd)
        {
            _money += dollarsTOAdd * _dollarsRatio;
        }
    }
}
