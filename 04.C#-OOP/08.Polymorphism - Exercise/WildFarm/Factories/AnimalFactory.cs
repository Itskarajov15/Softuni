using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public static Animal CreateAnimal(string[] animalData)
        {
            var type = animalData[0];
            var name = animalData[1];
            var weight = int.Parse(animalData[2]);

            if (type == nameof(Owl))
            {
                var wingSize = double.Parse(animalData[3]);

                return new Owl(name, weight, wingSize);
            }
            else if (type == nameof(Hen))
            {
                var wingSize = double.Parse(animalData[3]);

                return new Hen(name, weight, wingSize);
            }
            else if (type == nameof(Mouse))
            {
                var livingRegion = animalData[3];

                return new Mouse(name, weight, livingRegion);
            }
            else if (type == nameof(Dog))
            {
                var livingRegion = animalData[3];

                return new Dog(name, weight, livingRegion);
            }
            else if (type == nameof(Cat))
            {
                var breed = animalData[3];

                return new Cat(name, weight, breed);
            }
            else if (type == nameof(Tiger))
            {
                var breed = animalData[3];

                return new Tiger(name, weight, breed);
            }
            else
            {
                return null;
            }
        }
    }
}
