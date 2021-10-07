using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            var cookedProducts = new Dictionary<string, int>()
            {
                { "Bread", 0},
                { "Cake", 0 },
                { "Fruit Pie", 0},
                { "Pastry", 0}
            };

            var liquids = new Queue<int>(ReadArrayFromTheConsole());
            var ingredients = new Stack<int>(ReadArrayFromTheConsole());

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currValue = liquids.Peek() + ingredients.Peek();

                if (CheckIfAProductIsCooked(currValue, cookedProducts))
                {
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    liquids.Dequeue();
                    ingredients.Push(ingredients.Pop() + 3);
                }
            }

            Console.WriteLine(ReturnIfAllProductsAreCooked(cookedProducts) ? "Wohoo! You succeeded in cooking all the food!"
                : "Ugh, what a pity! You didn't have enough materials to cook everything.");

            Console.WriteLine(liquids.Count > 0 ? $"Liquids left: {String.Join(", ", liquids)}" : "Liquids left: none");

            Console.WriteLine(ingredients.Count > 0 ? $"Ingredients left: {String.Join(", ", ingredients)}" : "Ingredients left: none");

            PrintCoockedProducts(cookedProducts);
        }

        private static void PrintCoockedProducts(Dictionary<string, int> cookedProducts)
        {
            foreach (var product in cookedProducts)
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
        }

        private static bool ReturnIfAllProductsAreCooked(Dictionary<string, int> cookedProducts)
        {
            cookedProducts = cookedProducts
                .Where(x => x.Value > 0)
                .ToDictionary(x => x.Key, x => x.Value);

            if (cookedProducts.Count == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CheckIfAProductIsCooked(int currValue, Dictionary<string, int> cookedProducts)
        {
            if (currValue == 25)
            {
                cookedProducts["Bread"]++;
                return true;
            }
            else if (currValue == 50)
            {
                cookedProducts["Cake"]++;
                return true;
            }
            else if (currValue == 75)
            {
                cookedProducts["Pastry"]++;
                return true;
            }
            else if (currValue == 100)
            {
                cookedProducts["Fruit Pie"]++;
                return true;
            }

            return false;
        }

        private static int[] ReadArrayFromTheConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
