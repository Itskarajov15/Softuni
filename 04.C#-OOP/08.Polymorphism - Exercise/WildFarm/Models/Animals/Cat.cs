using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string breed) 
            : base(name, weight, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override void Eat(string food, int quantity)
        {
            //

            base.Eat(food, quantity);
        }
    }
}
