using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int capacityOfRack = int.Parse(Console.ReadLine());

            Stack<int> box = new Stack<int>(input);

            int numberOfRacks = 1;

            int sum = 0;

            while (box.Count > 0)
            {
                sum += box.Peek();

                if (sum <= capacityOfRack)
                {
                    box.Pop();
                }
                else
                {
                    sum = 0;
                    numberOfRacks++;
                }
            }

            Console.WriteLine(numberOfRacks);
        }
    }
}
