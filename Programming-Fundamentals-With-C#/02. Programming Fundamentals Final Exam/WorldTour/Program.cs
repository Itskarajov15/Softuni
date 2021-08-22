using System;

namespace WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string travelPlan = Console.ReadLine();

            string[] commands = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Travel")
            {
                if (commands[0] == "Add Stop")
                {
                    int index = int.Parse(commands[1]);
                    string text = commands[2];

                    if (index < 0 || index >= travelPlan.Length)
                    {
                        commands = Console.ReadLine()
                        .Split(":", StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(travelPlan);
                        continue;
                    }

                    travelPlan = travelPlan.Insert(index, text);

                    Console.WriteLine(travelPlan);
                }
                else if (commands[0] == "Remove Stop")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if ((startIndex < 0 || startIndex >= travelPlan.Length) || (endIndex < 0 || endIndex >= travelPlan.Length))
                    {
                        commands = Console.ReadLine()
                        .Split(":", StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(travelPlan);
                        continue;
                    }

                    travelPlan = travelPlan.Remove(startIndex, endIndex - startIndex + 1);

                    Console.WriteLine(travelPlan);
                }
                else if (commands[0] == "Switch")
                {
                    string oldString = commands[1];
                    string newString = commands[2];

                    if (!travelPlan.Contains(oldString))
                    {
                        commands = Console.ReadLine()
                        .Split(":", StringSplitOptions.RemoveEmptyEntries);
                        Console.WriteLine(travelPlan);
                        continue;
                    }

                    travelPlan = travelPlan.Replace(oldString, newString);

                    Console.WriteLine(travelPlan);
                }

                commands = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {travelPlan}");
        }
    }
}
