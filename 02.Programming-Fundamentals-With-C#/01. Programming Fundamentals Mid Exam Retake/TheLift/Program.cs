using System;
using System.Linq;

namespace TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleInTheQueue = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < lift.Length; i++)
            {
                if (lift[i] < 4)
                {
                    int neededPeople = 4 - lift[i];
                    peopleInTheQueue -= neededPeople;

                    if (peopleInTheQueue <= 0)
                    {
                        neededPeople -= Math.Abs(peopleInTheQueue);
                        lift[i] += neededPeople;
                        break;
                    }

                    lift[i] += neededPeople;
                }
            }

            for (int i = 0; i < lift.Length; i++)
            {
                if (lift[i] < 4)
                {
                    Console.WriteLine("The lift has empty spots!");
                    break;
                }
            }

            if (peopleInTheQueue > 0)
            {
                Console.WriteLine($"There isn't enough space! {peopleInTheQueue} people in a queue!");
            }

            Console.WriteLine(String.Join(" ", lift));
        }
    }
}
