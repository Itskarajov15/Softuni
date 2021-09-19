using System;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> raritiesByPlants = new Dictionary<string, int>();
            Dictionary<string, List<int>> ratingsByPlants = new Dictionary<string, List<int>>();

            int numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] input = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);

                string plant = input[0];
                int rarity = int.Parse(input[1]);

                if (!raritiesByPlants.ContainsKey(plant))
                {
                    raritiesByPlants.Add(plant, rarity);
                    ratingsByPlants.Add(plant, new List<int>());
                }
                else
                {
                    raritiesByPlants[plant] = rarity;
                }
            }

            string[] commands = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Exhibition")
            {
                if (commands[0] == "Rate:")
                {
                    string plant = commands[1];
                    int rating = int.Parse(commands[3]);

                    if (!raritiesByPlants.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    ratingsByPlants[plant].Add(rating);
                }
                else if (commands[0] == "Update:")
                {
                    string plant = commands[1];
                    int newRarity = int.Parse(commands[3]);

                    if (!raritiesByPlants.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    raritiesByPlants[plant] = newRarity;
                }
                else if (commands[0] == "Reset:")
                {
                    string plant = commands[1];

                    if (!ratingsByPlants.ContainsKey(plant))
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    ratingsByPlants.Remove(plant);

                    ratingsByPlants.Add(plant, new List<int>());
                }
                else
                {
                    Console.WriteLine("error");
                }

                commands = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }


            Dictionary<string, double> averageRating = new Dictionary<string, double>();

            foreach (var plant in ratingsByPlants)
            {
                double average = plant.Value.Average();

                averageRating.Add(plant.Key, average);
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in raritiesByPlants
                .OrderByDescending(x => x.Value).ThenBy(x => x.Key.Average()).ToDictionary(x => x.Key, x => x.Value))
            {
                Console.WriteLine($"- {plant.Key}; Rarity: {raritiesByPlants[plant.Key]}; Rating: {averageRating[plant.Key]:f2}");
            }
        }
    }
}
