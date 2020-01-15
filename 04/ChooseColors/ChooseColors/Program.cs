using System;

namespace ChooseColors
{
    class Program
    {
        enum Colors
        {
            Black,
            Blue,
            Cyan,
            Grey,
            Green,
            Magenta,
            Red,
            White,
            Yellow
        };

        static void Main(string[] args)
        {
            int[] arr = new int[4];
            int temp = 0;
            int loveColors;
            Colors allColors = Colors.Black | Colors.Blue | Colors.Cyan | Colors.Grey | Colors.Green | Colors.Magenta | Colors.Red | Colors.White | Colors.Yellow;

            Console.WriteLine(allColors);

            Console.WriteLine("Укажите любимые цвета: ");
            for (int i = 0; i < 4; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                temp |= arr[i];
            }

            loveColors = (int)allColors & temp;

            Console.WriteLine(Convert.ToString(loveColors, 2));





        }
    }
}
