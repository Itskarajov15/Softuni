using System;
using System.Linq;
using System.Collections.Generic;

namespace MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string[] command = Console.ReadLine()
                .Split();

            while (command[0] != "End")
            {
                if (command[0] == "Shoot")
                {
                    int index = int.Parse(command[1]);
                    int power = int.Parse(command[2]);

                    targets = ShootingTargetsWithGivenPower(targets, index, power);
                }
                else if (command[0] == "Add")
                {
                    int index = int.Parse(command[1]);
                    int value = int.Parse(command[2]);

                    if (index >= 0 && index < targets.Count)
                    {
                        targets = InsertingValueAtGivenIndex(targets, index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                else if (command[0] == "Strike")
                {
                    int index = int.Parse(command[1]);
                    int radius = int.Parse(command[2]);

                    if (index - radius < 0 || index + radius >= targets.Count)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        targets = RemoveTargetsInGivenRadius(targets, index, radius);
                    }
                }

                command = Console.ReadLine()
                .Split();
            }

            Console.WriteLine(String.Join('|', targets));
        }

        static List<int> RemoveTargetsInGivenRadius(List<int> targets, int index, int radius)
        {
            List<int> result = targets;

            for (int i = 0; i < targets.Count; i++)
            {
                if (i < 0 || i >= result.Count)
                {
                    return targets;
                }
                else
                {
                    if (i >= index - radius && i <= index + radius)
                    {
                        result.RemoveAt(i);
                        i = -1;
                    }
                }
            }

            return result;
        }

        static List<int> InsertingValueAtGivenIndex(List<int> targets, int index, int value)
        {
            targets.Insert(index, value);

            return targets;
        }

        static List<int> ShootingTargetsWithGivenPower(List<int> targets, int index, int power)
        {
            if (index < 0 || index >= targets.Count)
            {
                return targets;
            }
            else
            {
                targets[index] -= power;

                if (targets[index] <= 0)
                {
                    targets.RemoveAt(index);
                }
            }

            return targets;
        }
    }
}
