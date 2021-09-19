using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int elementsToPushIn = commands[0];
            int elementsToPopOut = commands[1];
            int elementToLookFor = commands[2];

            Stack<int> intStack = new Stack<int>(elementsToPushIn);

            PushElements(intStack, numbers, elementsToPushIn);
            PopElements(intStack, elementsToPopOut);
            Checks(intStack, elementToLookFor);
        }

        static void Checks(Stack<int> intStack, int elementToLookFor)
        {
            if (intStack.Any())
            {
                if (intStack.Contains(elementToLookFor))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(intStack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        static void PopElements(Stack<int> intStack, int elementsToPopOut)
        {
            for (int i = 0; i < elementsToPopOut; i++)
            {
                intStack.Pop();
            }
        }

        static void PushElements(Stack<int> intStack, List<int> numbers, int elementsToPushIn)
        {
            for (int i = 0; i < elementsToPushIn; i++)
            {
                intStack.Push(numbers[i]);
            }
        }
    }
}
