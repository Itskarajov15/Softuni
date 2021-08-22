using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>
            {
                {"shards", 0},
                {"fragments", 0},
                {"motes", 0}
            };

            Dictionary<string, int> junk = new Dictionary<string, int>();

            bool isEnough = false;

            string winnerMaterial = String.Empty;

            while (!isEnough)
            {
                string[] input = Console.ReadLine()
                    .Split();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (materials.ContainsKey(material))
                    {
                        materials[material] += quantity;

                        if (materials[material] >= 250)
                        {
                            isEnough = true;
                            winnerMaterial = material;
                            materials[material] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(material))
                        {
                            junk[material] += quantity;
                        }
                        else
                        {
                            junk.Add(material, quantity);
                        }
                    }
                }
            }

            string legendaryItem = String.Empty;

            if (winnerMaterial == "shards")
            {
                legendaryItem = "Shadowmourne";
            }
            else if (winnerMaterial == "fragments")
            {
                legendaryItem = "Valanyr";
            }
            else if (winnerMaterial == "motes")
            {
                legendaryItem = "Dragonwrath";
            }

            Console.WriteLine($"{legendaryItem} obtained!");

            Dictionary<string, int> sortedMaterials = materials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            Dictionary<string, int> sortedJunkItems = junk
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedJunkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
