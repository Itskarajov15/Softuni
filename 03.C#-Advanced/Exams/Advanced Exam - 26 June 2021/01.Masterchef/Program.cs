using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> dishes = new SortedDictionary<string, int>();

            int[] sequenceOfIngredients = ReadIntArrayFromTheConsole();

            int[] sequenceOfFreshnessValues = ReadIntArrayFromTheConsole();

            Queue<int> ingredients = new Queue<int>(sequenceOfIngredients);
            Stack<int> freshnessValues = new Stack<int>(sequenceOfFreshnessValues);

            while (ingredients.Count > 0 && freshnessValues.Count > 0)
            {
                int ingredient = ingredients.Dequeue();

                if (ingredient == 0)
                {
                    continue;
                }

                int freshnessValue = freshnessValues.Pop();

                int sum = ingredient * freshnessValue;

                if (sum == 150)
                {
                    string dish = "Dipping sauce";

                    AddTheDishInTheDict(dish, dishes);
                }
                else if (sum == 250)
                {
                    string dish = "Green salad";

                    AddTheDishInTheDict(dish, dishes);
                }
                else if (sum == 300)
                {
                    string dish = "Chocolate cake";

                    AddTheDishInTheDict(dish, dishes);
                }
                else if (sum == 400)
                {
                    string dish = "Lobster";

                    AddTheDishInTheDict(dish, dishes);
                }
                else
                {
                    ingredients.Enqueue(ingredient + 5);
                }
            }

            if (dishes.Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes! ");
            }
            else
            {
                Console.WriteLine($"You were voted off. Better luck next year.");

                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
            }

            foreach (var dish in dishes)
            {
                Console.WriteLine($"# {dish.Key} --> {dish.Value}");
            }
        }

        static void AddTheDishInTheDict(string dish, SortedDictionary<string, int> dishes)
        {
            if (!dishes.ContainsKey(dish))
            {
                dishes.Add(dish, 0);
            }

            dishes[dish]++;
        }

        static int[] ReadIntArrayFromTheConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
