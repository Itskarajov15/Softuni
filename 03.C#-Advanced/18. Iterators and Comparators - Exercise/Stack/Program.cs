using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack<int>();

            var command = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "END")
            {
                if (command[0] == "Push")
                {
                    stack.Push(command.Skip(1).Select(int.Parse).ToList());
                }
                else if (command[0] == "Pop")
                {
                    try
                    {
                        stack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                command = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            }

            PrintEachElementFromTheList(stack);
            PrintEachElementFromTheList(stack);
        }

        private static void PrintEachElementFromTheList(CustomStack<int> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}
