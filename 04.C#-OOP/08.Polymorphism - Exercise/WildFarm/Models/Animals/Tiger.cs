﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }

        public override void Eat(string food, int quantity)
        {
            if (!Validator.MeatValidator(food))
            {
                throw new InvalidOperationException($"{this.GetType().Name} does not eat {food}!");
            }

            this.Weight += quantity * 1;

            base.Eat(food, quantity);
        }
    }
}
