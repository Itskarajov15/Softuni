using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();

            Stack<string> strStack = new Stack<string>(input);

            while (strStack.Count > 1)
            {
                int a = int.Parse(strStack.Pop());
                string op = strStack.Pop();
                int b = int.Parse(strStack.Pop());
                int result = 0;

                if (op == "+")
                {
                    result = a + b;
                }
                else if (op == "-")
                {
                    result = a - b;
                }

                strStack.Push(result.ToString());
            }

            Console.WriteLine(strStack.Pop());
        }
    }
}
