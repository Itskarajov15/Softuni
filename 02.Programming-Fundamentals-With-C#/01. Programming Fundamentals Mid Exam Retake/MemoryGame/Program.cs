using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            int moves = 1;

            string[] command = Console.ReadLine()
                .Split();

            while (command[0] != "end")
            {
                int firstIndex = int.Parse(command[0]);
                int secondIndex = int.Parse(command[1]);

                if ((firstIndex < 0 || firstIndex >= sequence.Count) || (secondIndex < 0 || secondIndex >= sequence.Count) || firstIndex == secondIndex)//
                {
                    sequence = InsertAdditionalElementsInTheSequence(sequence, firstIndex, secondIndex, moves);

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else if (sequence[firstIndex] != sequence[secondIndex])
                {
                    Console.WriteLine("Try again!");
                }
                else
                {
                    Console.WriteLine($"Congrats! You have found matching elements - {sequence[firstIndex]}!");

                    sequence = RemovesElementsFromTheSequence(sequence, firstIndex, secondIndex);
                }

                if (sequence.Count <= 0)
                {
                    Console.WriteLine($"You have won in {moves} turns!");
                    break;
                }

                moves++;

                command = Console.ReadLine()
                .Split();
            }

            if (command[0] == "end")
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(String.Join(" ", sequence));
            }
        }

        static List<string> InsertAdditionalElementsInTheSequence(List<string> sequence, int firstIndex, int secondIndex, int moves)
        {
            int middle = sequence.Count / 2;

            sequence.Insert(middle, $"-{moves}a");
            sequence.Insert(middle, $"-{moves}a");

            return sequence;
        }

        static List<string> RemovesElementsFromTheSequence(List<string> sequence, int firstIndex, int secondIndex)
        {
            int biggerIndex = Math.Max(firstIndex, secondIndex);
            int smallerIndex = Math.Min(firstIndex, secondIndex);

            if (sequence[firstIndex] == sequence[secondIndex])
            {
                sequence.RemoveAt(biggerIndex);
                sequence.RemoveAt(smallerIndex);
            }

            return sequence;
        }
    }
}
