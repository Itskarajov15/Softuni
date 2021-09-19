using System;
using System.Collections.Generic;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> peopleInTheQueue = new Queue<string>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    while (peopleInTheQueue.Count > 0)
                    {
                        Console.WriteLine(peopleInTheQueue.Dequeue());
                    }
                }
                else
                {
                    peopleInTheQueue.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{peopleInTheQueue.Count} people remaining.");
        }
    }
}
