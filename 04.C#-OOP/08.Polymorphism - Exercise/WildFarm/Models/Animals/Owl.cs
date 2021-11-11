using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }

        public override void Eat(string food, int quantity)
        {
            if (!Validator.MeatValidator(food))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food}!");
            }

            this.Weight += quantity * 0.25;

            base.Eat(food, quantity);
        }
    }
}
