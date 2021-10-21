using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            var lilies = new Stack<int>(ReadArray());
            var roses = new Queue<int>(ReadArray());

            var countOfWreaths = 0;
            var flowersLeft = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                CreateWreaths(lilies, roses, ref countOfWreaths, ref flowersLeft);
            }

            if (flowersLeft / 15 > 0)
            {
                countOfWreaths += flowersLeft / 15;
            }

            if (countOfWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths} wreaths more!");
            }
        }

        private static void CreateWreaths(Stack<int> lilies, Queue<int> roses, ref int countOfWreaths, ref int flowersLeft)
        {
            if (lilies.Peek() + roses.Peek() == 15)
            {
                countOfWreaths++;
                lilies.Pop();
                roses.Dequeue();
            }
            else if (lilies.Peek() + roses.Peek() > 15)
            {
                lilies.Push(lilies.Pop() - 2);

                CreateWreaths(lilies, roses, ref countOfWreaths, ref flowersLeft);
            }
            else
            {
                flowersLeft += lilies.Pop() + roses.Dequeue();
            }
        }

        private static int[] ReadArray()
        {
            return Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
