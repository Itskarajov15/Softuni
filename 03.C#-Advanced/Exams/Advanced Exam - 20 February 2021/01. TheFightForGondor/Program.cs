using System;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWaves = int.Parse(Console.ReadLine());

            var inputPlates = ReadIntArrayFromTheConsole();

            bool orcsWon = false;

            var plates = new Queue<int>(inputPlates);
            var orcs = new Stack<int>();

            for (int i = 1; i <= numberOfWaves; i++)
            {
                var orcsInput = ReadIntArrayFromTheConsole();
                orcs = new Stack<int>(orcsInput);

                if (i % 3 == 0 && i != 0)
                {
                    int plate = int.Parse(Console.ReadLine());

                    plates.Enqueue(plate);
                }

                while (orcs.Count != 0 && plates.Count != 0)
                {
                    if (orcs.Peek() > plates.Peek())
                    {
                        orcs.Push(orcs.Pop() - plates.Dequeue());
                    }
                    else if (plates.Peek() > orcs.Peek())
                    {
                        plates.Enqueue(plates.Dequeue() - orcs.Pop());

                        for (int j = 1; j < plates.Count; j++)
                        {
                            plates.Enqueue(plates.Dequeue());
                        }
                    }
                    else
                    {
                        plates.Dequeue();
                        orcs.Pop();
                    }
                }

                if (plates.Count <= 0)
                {
                    orcsWon = true;
                    break;
                }
            }

            if (orcsWon)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");

                if (orcs.Count > 0)
                {
                    Console.WriteLine($"Orcs left: {String.Join(", ", orcs)}");
                }
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");

                if (plates.Count > 0)
                {
                    Console.WriteLine($"Plates left: {String.Join(", ", plates)}");
                }
            }
        }

        private static int[] ReadIntArrayFromTheConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
