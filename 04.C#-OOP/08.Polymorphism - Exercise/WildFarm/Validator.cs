using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm
{
    public static class Validator
    {
        public static bool MeatValidator(string typeOfFood)
        {
            if (typeOfFood == nameof(Meat))
            {
                return true;
            }

            return false;
        }

        public static bool FruitValidator(string typeOfFood)
        {
            if (typeOfFood == nameof(Fruit))
            {
                return true;
            }

            return false;
        }

        public static bool VegetableValidator(string typeOfFood)
        {
            if (typeOfFood == nameof(Vegetable))
            {
                return true;
            }

            return false;
        }
    }
}
