using System;
using System.Collections.Generic;
using System.Linq;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split()
                .ToList();

            string[] command = Console.ReadLine()
                .Split();

            while (command[0] != "3")
            {
                if (command[0] == "merge")
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);

                    input = MergeElementsInTheGivenRange(input, startIndex, endIndex);
                }

                command = Console.ReadLine()
                .Split();
            }
        }

        static List<string> MergeElementsInTheGivenRange(List<string> input, int startIndex, int endIndex)
        {
            string mergedElements = String.Empty;

            for (int i = startIndex; i <= endIndex; i++)
            {
                if (i < 0 || i >= input.Count)
                {
                    continue;
                }

                mergedElements += input[i];
                input.RemoveAt(i);
            }

            return input;
        }
    }
}
