using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> player = new Queue<string>(songs);

            string command = Console.ReadLine();

            while (player.Count > 0)
            {
                if (command.Contains("Add"))
                {
                    string songName = command.Substring(4);

                    if (!player.Contains(songName))
                    {
                        player.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                }
                else if (command.Contains("Play"))
                {
                    player.Dequeue();
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(String.Join(", ", player));
                }

                command = Console.ReadLine();
            }

            if (!player.Any())
            {
                Console.WriteLine("No more songs!");
            }
        }
    }
}
