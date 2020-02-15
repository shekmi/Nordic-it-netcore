using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork13
{
    class Plane : Aircraft
    {
        public byte EnginesCount { get; private set; }

        public Plane(int maxHeight, byte enginesCount) : base(maxHeight)
        {
            EnginesCount = enginesCount;
            Console.WriteLine("It’s a plane, welcome aboard!");
        }

        public override void WriteAllProperties()
        {
            base.WriteAllProperties();
            Console.WriteLine(          
            $"Properties of Plane: \n" + 
            $"EnginesCount: {EnginesCount}");
        }

    }
}
