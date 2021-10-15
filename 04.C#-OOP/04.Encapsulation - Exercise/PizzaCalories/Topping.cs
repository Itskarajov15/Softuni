using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const int MinGrams = 1;
        private const int MaxGrams = 50;

        private string toppingType;
        private int toppingWeight;

        public Topping(string toppingType, int toppingWeight)
        {
            this.ToppingType = toppingType;
            this.ToppingWeight = toppingWeight;
        }

        public string ToppingType
        {
            get => this.toppingType;
            private set
            {
                Validator.ThrowIfValueIsInvalid(new HashSet<string> { "meat", "veggies", "cheese", "sauce" }
                , value.ToLower()
                , $"Cannot place {value} on top of your pizza.");

                this.toppingType = value;
            }
        }
        public int ToppingWeight
        {
            get => this.toppingWeight;
            private set
            {
                Validator.CheckIfNumberIsInRange(MinGrams
                    , MaxGrams
                    , value
                    , $"{this.ToppingType} weight should be in the range [1..50].");

                this.toppingWeight = value;
            }
        }

        public double GetCalories()
        {
            var toppingTypeModifier = GetToppingTypeModifier();

            return this.ToppingWeight * 2 * toppingTypeModifier;
        }

        private double GetToppingTypeModifier()
        {
            var toppingTypeToLower = this.ToppingType.ToLower();

            if (toppingTypeToLower == "meat")
            {
                return 1.2;
            }
            else if (toppingTypeToLower == "veggies")
            {
                return 0.8;
            }
            else if (toppingTypeToLower == "cheese")
            {
                return 1.1;
            }

            return 0.9;
        }
    }
}
