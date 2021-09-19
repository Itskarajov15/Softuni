using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> charStack = new Stack<char>();

            foreach (char item in input)
            {
                if (item == '{' || item == '[' || item == '(')
                {
                    charStack.Push(item);
                }
                else if ((item == '}' || item == ']' || item == ')') && charStack.Count > 0)
                {
                    if (charStack.Peek() == '(' && item == ')' || charStack.Peek() == '{' && item == '}' || charStack.Peek() == '[' && item == ']')
                    {
                        charStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
        }
    }
}
