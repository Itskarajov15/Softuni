using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Factories
{
    public class FoodFactory
    {
        public Food CreateFood(string[] foodData)
        {
            var type = foodData[0];
            var quantity = int.Parse(foodData[1]);

            if (type == nameof(Vegetable))
            {
                return new Vegetable(quantity);
            }
            else if (type == nameof(Fruit))
            {
                return new Fruit(quantity);
            }
            else if (type == nameof(Meat))
            {
                return new Meat(quantity);
            }
            else if (type == nameof(Seeds))
            {
                return new Seeds(quantity);
            }
            else
            {
                return null;
            }
        }
    }
}
