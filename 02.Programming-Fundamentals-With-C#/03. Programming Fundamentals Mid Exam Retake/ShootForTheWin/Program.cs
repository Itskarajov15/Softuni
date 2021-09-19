using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = Console.ReadLine();

            while (command != "End")
            {
                int index = int.Parse(command);

                if (index >= 0 && index < sequence.Length)
                {
                    if (sequence[index] != -1)
                    {
                        int currentTarget = sequence[index];
                        sequence[index] = -1;

                        sequence = ReducingOrIncreasingNumbersInTheSequence(sequence, index, currentTarget);
                    }
                }
                else
                {
                    command = Console.ReadLine();
                    continue;
                }

                command = Console.ReadLine();
            }

            int numberOfShotTargets = ReturnTheNumberOfShotTargets(sequence);

            Console.WriteLine($"Shot targets: {numberOfShotTargets} -> {String.Join(" ", sequence)}");
        }

        static int ReturnTheNumberOfShotTargets(int[] sequence)
        {
            int count = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == -1)
                {
                    count++;
                }
            }

            return count;
        }

        static int[] ReducingOrIncreasingNumbersInTheSequence(int[] sequence, int index, int currentTarget)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                if (index != i && sequence[i] != -1)
                {
                    if (sequence[i] > currentTarget)
                    {
                        sequence[i] -= currentTarget;
                    }
                    else
                    {
                        sequence[i] += currentTarget;
                    }
                }
            }

            return sequence;
        }
    }
}
