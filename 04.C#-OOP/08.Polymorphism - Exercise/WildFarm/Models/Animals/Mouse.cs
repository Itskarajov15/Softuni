using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }

        public override void Eat(string food, int quantity)
        {
            if (!Validator.VegetableValidator(food) && !Validator.FruitValidator(food))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food}!");
            }

            this.Weight += quantity * 0.1;

            base.Eat(food, quantity);
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
