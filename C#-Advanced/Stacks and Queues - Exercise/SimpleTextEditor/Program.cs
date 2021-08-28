using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> previousCommands = new Stack<string>();

            string text = String.Empty;

            int numberOfOperations = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfOperations; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "1")
                {
                    previousCommands.Push(text);
                    text += command[1];
                }
                else if (command[0] == "2")
                {
                    previousCommands.Push(text);

                    int countOfSymbolsToErase = int.Parse(command[1]);

                    text = text.Substring(0, text.Length - countOfSymbolsToErase);
                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]);

                    Console.WriteLine(text[index - 1]);
                }
                else if (command[0] == "4")
                {
                    text = previousCommands.Pop();
                }
            }
        }
    }
}
