using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int[]> petrolPumps = new Queue<int[]>();

            int countOfPetrolPumps = int.Parse(Console.ReadLine());

            EnqueuePetrolPumps(petrolPumps, countOfPetrolPumps);

            int index = 0;

            while (true)
            {
                int tank = 0;

                foreach (int[] petrolPump in petrolPumps)
                {
                    int petrolAmount = petrolPump[0];
                    int distance = petrolPump[1];

                    tank += petrolAmount - distance;

                    if (tank < 0)
                    {
                        petrolPumps.Enqueue(petrolPumps.Dequeue());
                        index++;
                        break;
                    }
                }

                if (tank >= 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }

        static void EnqueuePetrolPumps(Queue<int[]> petrolPumps, int countOfPetrolPumps)
        {
            for (int i = 0; i < countOfPetrolPumps; i++)
            {
                int[] petrolPump = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                petrolPumps.Enqueue(petrolPump);
            }
        }
    }
}
