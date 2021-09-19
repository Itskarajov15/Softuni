using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
             .Split(" ", StringSplitOptions.RemoveEmptyEntries)
             .Select(int.Parse)
             .ToArray();

            Stack<int> intStack = new Stack<int>(numbers);

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0].ToLower() != "end")
            {
                if (command[0].ToLower() == "add")
                {
                    int firstNumber = int.Parse(command[1]);
                    int secondNumber = int.Parse(command[2]);

                    intStack.Push(firstNumber);
                    intStack.Push(secondNumber);
                }
                else if (command[0].ToLower() == "remove")
                {
                    int count = int.Parse(command[1]);

                    if (count > intStack.Count)
                    {
                        command = Console.ReadLine()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    for (int i = 0; i < count; i++)
                    {
                        intStack.Pop();
                    }
                }

                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            int sum = intStack.Sum();

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
