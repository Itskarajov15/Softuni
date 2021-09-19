using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> intStack = new Stack<int>();

            int numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int numberOfCommand = command[0];

                if (numberOfCommand == 1)
                {
                    int numberToPushIn = command[1];

                    intStack.Push(numberToPushIn);
                }
                else if (numberOfCommand == 2)
                {
                    if (intStack.Any())
                    {
                        intStack.Pop();
                    }
                }
                else if (numberOfCommand == 3)
                {
                    if (intStack.Any())
                    {
                        Console.WriteLine(intStack.Max());
                    }
                }
                else if (numberOfCommand == 4)
                {
                    if (intStack.Any())
                    {
                        Console.WriteLine(intStack.Min());
                    }
                }
            }

            Console.WriteLine(String.Join(", ", intStack));
        }
    }
}
