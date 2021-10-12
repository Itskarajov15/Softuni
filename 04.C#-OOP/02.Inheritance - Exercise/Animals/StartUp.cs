using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> listOfAnimals = new List<Animal>();

            while (true)
            {
                string typeOfAnimal = Console.ReadLine();

                if (typeOfAnimal == "Beast!")
                {
                    break;
                }

                var infoAboutTheAnimal = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = infoAboutTheAnimal[0];
                int age = int.Parse(infoAboutTheAnimal[1]);
                string gender = infoAboutTheAnimal[2];

                if (String.IsNullOrEmpty(name) || age <= 0 || String.IsNullOrEmpty(gender))
                {
                    continue;
                }

                switch (typeOfAnimal)
                {
                    case "Dog": listOfAnimals.Add(new Dog(name, age, gender));
                        break;
                    case "Cat": listOfAnimals.Add(new Cat(name, age, gender));
                        break;
                    case "Frog": listOfAnimals.Add(new Frog(name, age, gender));
                        break;
                    case "Kitten": listOfAnimals.Add(new Kitten(name, age));
                        break;
                    case "Tomcat": listOfAnimals.Add(new Tomcat(name, age));
                        break;
                }
            }

            foreach (var animal in listOfAnimals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
