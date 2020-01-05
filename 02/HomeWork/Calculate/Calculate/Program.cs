using System;

namespace Calculate
{
    class Program
    {
        static void Main()
        {
            double variableFirst = 0;
            double variableSecond = 0;
            double result = 0;
            string temp;

            try
            {
                Console.WriteLine("Enter first value:");
                temp = Console.ReadLine();
                variableFirst = int.Parse(temp);
                Console.WriteLine("Enter second value:");
                temp = Console.ReadLine();
                variableSecond = int.Parse(temp);

                Console.WriteLine("Enter the type of operation:");
                temp = Console.ReadLine();

                switch (temp)
                {
                    case "+":
                        Console.WriteLine("Result: {0}", (variableFirst + variableSecond));
                        break;
                    case "-":
                        Console.WriteLine("Result: {0}", (variableFirst - variableSecond));
                        break;
                    case "*":
                        Console.WriteLine("Result: {0}", (variableFirst * variableSecond));
                        break;
                    case "/":
                        if (variableSecond == 0)
                        {
                            Console.WriteLine("Division by 0!!!");
                        }
                        else
                        {
                            Console.WriteLine("Result: {0}", (variableFirst / variableSecond));
                            result = variableFirst / variableSecond;
                        }
                        break;
                    case "%":
                        if (variableSecond == 0)
                        {
                            Console.WriteLine("Division by 0!!!");
                        }
                        else
                        {
                            Console.WriteLine("Result: {0}", (variableFirst % variableSecond));
                        }
                        break;
                    case "^":
                        Console.WriteLine("Result: {0}", Math.Pow(variableFirst, variableSecond));
                        break;
                    default:
                        Console.WriteLine("You must enter correct operation (+, -, *, /, %, ^)");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
