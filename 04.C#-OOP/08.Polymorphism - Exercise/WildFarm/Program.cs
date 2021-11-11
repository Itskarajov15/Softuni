using System;
using System.Collections.Generic;
using WildFarm.Models.Animals;
using WildFarm.Factories;
using WildFarm.Models.Food;

namespace WildFarm
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();

            var animals = new List<Animal>();

            var input = Console.ReadLine();

            while(input != "End")
            {
                string[] animalArgs = input
                    .Split();

                string[] foodArgs = Console.ReadLine()
                    .Split();

                string foodType = foodArgs[0];
                int quantity = int.Parse(foodArgs[1]);

                Food food = foodFactory.CreateFood(foodArgs);
                Animal animal = animalFactory.CreateAnimal(animalArgs);

                Console.WriteLine(animal.ProduceSound());

                try
                {
                    animal.Eat(foodType, quantity);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                animals.Add(animal);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
