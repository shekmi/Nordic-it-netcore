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
            string temp = "", codeError = "";

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

                if (variableSecond == 0 && (temp == "/" || temp == "%"))
                {
                    codeError = "Division by 0!!!";
                }
                else
                {
                    switch (temp)
                    {
                        case "+":
                            result = variableFirst + variableSecond;
                            break;
                        case "-":
                            result = variableFirst - variableSecond;
                            break;
                        case "*":
                            result = variableFirst * variableSecond;
                            break;
                        case "/":
                            result = variableFirst / variableSecond;                     
                            break;
                        case "%":                         
                            result = variableFirst % variableSecond;                 
                            break;
                        case "^":
                            result = Math.Pow(variableFirst, variableSecond);
                            break;
                        default:
                            codeError = "You must enter correct operation (+, -, *, /, %, ^)";
                            break;
                    }
                }
                if (codeError != "")
                {
                    Console.WriteLine("Error: " + codeError);
                }
                else
                {
                    Console.WriteLine("Result = {0}", result);
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
