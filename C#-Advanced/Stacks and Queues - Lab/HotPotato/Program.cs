using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int number = int.Parse(Console.ReadLine());

            Queue<string> participants = new Queue<string>(input);

            while (participants.Count > 1)
            {
                for (int i = 1; i < number; i++)
                {
                    participants.Enqueue(participants.Dequeue());
                }

                Console.WriteLine($"Removed {participants.Dequeue()}");               
            }

            Console.WriteLine($"Last is {participants.Dequeue()}");
        }
    }
}
