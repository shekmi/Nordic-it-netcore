using System;
using System.Collections.Generic;

namespace HomeWork_8
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "()";            // True
            var s2 = "[]()";          // True
            var s3 = "[[]()]";        // True
            var s4 = "([([])])()[]";  // True

            var s5 = "(";             // False
            var s6 = "[][)";          // False
            var s7 = "[(])";          // False
            var s8 = "(()[]]";        // False
            var s9 = "(]";            // False

            string str = s8;
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> dictionary = new Dictionary<char, char>()
            {
                { '(' , ')' }, 
                { '[' , ']' }
            };
            bool flag = false;
            for (int i = 0; i < str.Length; i++)
            {
                stack.Push(str[i]);          
                if (stack.Peek() != '[' && stack.Peek() != '(')
                {
                    char simvValue = stack.Pop();
                    char simvKey = stack.Pop();
                    if (dictionary[simvKey] == simvValue)
                    {
                        flag = true;                        
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }                    
            }       

            Console.WriteLine(flag);
        }
    }
}
