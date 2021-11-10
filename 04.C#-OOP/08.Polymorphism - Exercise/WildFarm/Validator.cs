using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm
{
    public static class Validator
    {
        public static void MeatValidator(string animalType, string typeOfFood)
        {
            if (typeOfFood != nameof(Meat))
            {
                throw new InvalidOperationException($"{animalType} does not eat {typeOfFood}!");
            }
        }

        public static void FruitValidator(string animalType, string typeOfFood)
        {
            if (typeOfFood != nameof(Fruit))
            {
                throw new InvalidOperationException($"{animalType} does not eat {typeOfFood}!");
            }
        }

        public static void VegetableValidator(string animalType, string typeOfFood)
        {
            if (typeOfFood != nameof(Vegetable))
            {
                throw new InvalidOperationException($"{animalType} does not eat {typeOfFood}!");
            }
        }
    }
}
