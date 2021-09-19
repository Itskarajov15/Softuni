using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstSequence = ReadIntArrayFromTheConsole();
            int[] secondSequence = ReadIntArrayFromTheConsole();

            Queue<int> firstBox = new Queue<int>(firstSequence);
            Stack<int> secondBox = new Stack<int>(secondSequence);

            int claimedItems = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firstItem = firstBox.Peek();
                int secondItem = secondBox.Peek();

                int sum = firstItem + secondItem;

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondItem);
                    secondBox.Pop();
                }
            }

            if (firstBox.Count <= 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }

        static int[] ReadIntArrayFromTheConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
