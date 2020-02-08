using System;

namespace ClassWork_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person()
            //{
            //    Name = "Anna",
            //    GetAge = 15
            //};

            //Console.WriteLine(person.PropertiesString());

            Pet pet1 = new Pet
            {
                Name = "Lucky",
                Kind = AnimalKind.Cat,              
                Sex = 'm',
                DateOfBirth = DateTimeOffset.Parse("2015-08-12")
            };
            pet1.SetBirthPlace("Moscow");
            pet1.WriteDescriptoin(true);

            Pet pet2 = new Pet("Radji", AnimalKind.Cat, 'm', DateTimeOffset.Parse("2012-10-5"), "Moscow");
            pet2.WriteDescriptoin(true);
        }
    }
}
