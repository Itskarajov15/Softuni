using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(string food, int quantity)
        {
            if (!Validator.VegetableValidator(food) && !Validator.MeatValidator(food))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food}!");
            }

            this.Weight += quantity * 0.3;

            base.Eat(food, quantity);
        }
    }
}
