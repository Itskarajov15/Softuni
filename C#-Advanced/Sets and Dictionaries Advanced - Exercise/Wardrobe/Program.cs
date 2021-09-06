using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(new[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

                FillingTheWardrobe(wardrobe, input);
            }

            string[] searchedItem = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clothes in color.Value)
                {
                    if (searchedItem[0] == color.Key && searchedItem[1] == clothes.Key)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
        static void FillingTheWardrobe(Dictionary<string, Dictionary<string, int>> wardrobe, string[] input)
        {
            string color = input[0];

            for (int j = 1; j < input.Length; j++)
            {
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                if (!wardrobe[color].ContainsKey(input[j]))
                {
                    wardrobe[color].Add(input[j], 0);
                }

                wardrobe[color][input[j]]++;
            }
        }
    }
}
