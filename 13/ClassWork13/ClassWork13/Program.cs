using System;

namespace ClassWork13
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane plane = new Plane(11000, 2);
            plane.EnginesCount = 2;
            plane.WriteAllProperties();
        }
    }
}
