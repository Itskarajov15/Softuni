using System;
using System.Collections.Generic;

namespace trafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> trafficJam = new Queue<string>(); 

            int numberOfCarsAllowedToPass = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            int count = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    if (trafficJam.Count <= numberOfCarsAllowedToPass)
                    {
                        count = CarsPassing(trafficJam, trafficJam.Count, count);
                    }
                    else
                    {
                        count = CarsPassing(trafficJam, numberOfCarsAllowedToPass, count);
                    }
                }
                else
                {
                    trafficJam.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"{count} cars passed the crossroads.");
        }

        static int CarsPassing(Queue<string> trafficJam, int n, int carsPassed)
        {
            for (int i = 0; i < n; i++)
            {
                carsPassed++;
                Console.WriteLine($"{trafficJam.Dequeue()} passed!");
            }

            return carsPassed;
        }
    }
}
