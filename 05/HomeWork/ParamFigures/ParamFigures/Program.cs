using System;

namespace ParamFigures
{
    class Program
    {
        enum Figure
        {
            Circle = 1,
            Triangle = 2,
            Rectangle = 3
        };
        static void Main()
        {
            string output = "";
            string outputSquare = "Площать поверхности: ";
            string outputPerimeter = "Длина периметра: ";
            double sFigure = 0;
            double pFigure = 0;
            try
            {
                Console.WriteLine("Укажите тип фигуры 1 - круг, 2 - равносторонний треугольник, 3 - прямоугольник: ");
                Figure typeFigure = (Figure)int.Parse(Console.ReadLine());
                switch (typeFigure)
                {
                    case Figure.Circle:
                        Console.WriteLine("Введите размер диаметра круга: ");
                        double diameter = double.Parse(Console.ReadLine());
                        sFigure = Math.Round((Math.PI / 4 * Math.Pow(diameter, 2)), 2);
                        pFigure = Math.Round((Math.PI * diameter), 2);
                        output = outputSquare + sFigure + "\n" + outputPerimeter + pFigure;
                        break;
                    case Figure.Triangle:
                        Console.WriteLine("Введите длину стороны треугольника: ");
                        double length = double.Parse(Console.ReadLine());
                        sFigure = Math.Round(((Math.Pow(length, 2) * Math.Sqrt(3)) / 4), 2);
                        pFigure = Math.Round((3 * length), 2);
                        output = outputSquare + sFigure + "\n" + outputPerimeter + pFigure;
                        break;
                    case Figure.Rectangle:
                        Console.WriteLine("Введите длину прямоугольника: ");
                        double width = double.Parse(Console.ReadLine());
                        Console.WriteLine("Введите высоту прямоугольника: ");
                        double height = double.Parse(Console.ReadLine());
                        sFigure = Math.Round((width * height), 2);
                        pFigure = Math.Round((2 * (width + height)), 2);
                        output = outputSquare + sFigure + "\n" + outputPerimeter + pFigure;
                        break;
                    default:
                        output = "Неверный тип фигуры";
                        break;
                }
                Console.WriteLine(output);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка! Введено нечисловое значение!");
            }
            Console.ReadKey();
        }
    }
}
