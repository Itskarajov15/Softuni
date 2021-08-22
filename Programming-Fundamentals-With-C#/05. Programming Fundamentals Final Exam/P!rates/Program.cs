using System;
using System.Collections.Generic;
using System.Linq;

namespace P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> populationOfTowns = new Dictionary<string, int>();
            Dictionary<string, int> goldOfTowns = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "Sail")
            {
                string[] parts = input.Split("||",StringSplitOptions.RemoveEmptyEntries);

                string town = parts[0];
                int population = int.Parse(parts[1]);
                int gold = int.Parse(parts[2]);

                if (!populationOfTowns.ContainsKey(town))
                {
                    populationOfTowns.Add(town, population);
                    goldOfTowns.Add(town, gold);
                }
                else
                {
                    populationOfTowns[town] += population;
                    goldOfTowns[town] += gold;
                }
                     
                input = Console.ReadLine();
            }

            string[] command = Console.ReadLine().Split("=>",StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                if (command[0] == "Plunder")
                {
                    string town = command[1];
                    int people = int.Parse(command[2]);
                    int gold = int.Parse(command[3]);

                    populationOfTowns[town] -= people;
                    goldOfTowns[town] -= gold;

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (populationOfTowns[town] <= 0 || goldOfTowns[town] <= 0)
                    {
                        populationOfTowns.Remove(town);
                        goldOfTowns.Remove(town);

                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else if (command[0] == "Prosper")
                {
                    string town = command[1];
                    int gold = int.Parse(command[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }

                    goldOfTowns[town] += gold;

                    Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {goldOfTowns[town]} gold.");
                }

                command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            if (populationOfTowns.Count > 0)
            {
                goldOfTowns = goldOfTowns
                    .OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"Ahoy, Captain! There are {goldOfTowns.Count} wealthy settlements to go to:");

                foreach (var town in goldOfTowns)
                {
                    string nameOfTown = town.Key;
                    int people = populationOfTowns[nameOfTown];
                    int gold = goldOfTowns[nameOfTown];

                    Console.WriteLine($"{nameOfTown} -> Population: {people} citizens, Gold: {gold} kg");
                }
            }
        }
    }
}
