using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }

        public override void Eat(string food, int quantity)
        {
            if (!Validator.MeatValidator(food))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food}!");
            }

            this.Weight += quantity * 0.4;

            base.Eat(food, quantity);
        }
    }
}
