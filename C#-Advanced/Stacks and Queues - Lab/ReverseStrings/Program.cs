using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<char> charStack = new Stack<char>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                charStack.Push(input[i]);
            }

            //for (int i = 0; i < input.length; i++)
            //{
            //    char currletter = strstack.pop();

            //    console.write(currletter);
            //}

            while (charStack.Count > 0)
            {
                char currletter = charStack.Pop();

                Console.Write(currletter);
            }
        }
    }
}
