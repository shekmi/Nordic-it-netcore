using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork13
{
    class Helicopter : Aircraft
    {
        public byte BladesCount { get; private set; }

        public Helicopter(int maxHeight, byte bladesCount) : base(maxHeight)
        {
            BladesCount = bladesCount;
            Console.WriteLine("It’s a helicopter, welcome aboard!");
        }

        public override void WriteAllProperties()
        {
            base.WriteAllProperties();
            Console.WriteLine(
            $"Properties of Helicopter: \n" +
            $"BladesCount: {BladesCount}\n");
        }

    }
}
