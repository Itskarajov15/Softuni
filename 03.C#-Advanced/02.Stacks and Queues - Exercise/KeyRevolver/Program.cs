using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceOfABullet = int.Parse(Console.ReadLine());
            int sizeOfTheGunBarrel = int.Parse(Console.ReadLine());

            List<int> bullets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> locks = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int intelligenceValue = int.Parse(Console.ReadLine());

            Stack<int> bulletsStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);

            int numberOfUsedBullets = 0;
            int count = 0;

            while (bulletsStack.Count > 0 && locksQueue.Count > 0)
            {
                if (bulletsStack.Pop() <= locksQueue.Peek())
                {
                    locksQueue.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                count++;

                if ((count == sizeOfTheGunBarrel) && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }

                numberOfUsedBullets++;
            }

            if (bulletsStack.Count >= 0 && locksQueue.Count <= 0)
            {
                Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${intelligenceValue - (numberOfUsedBullets * priceOfABullet)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
        }
    }
}
