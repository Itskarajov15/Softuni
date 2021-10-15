using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private const int maxToppingCount = 10;
        private const int MinNum = 1;
        private const int MaxNum = 15;

        private string name;
        private Dough dough;

        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                Validator.CheckIfNumberIsInRange(MinNum
                    , MaxNum
                    , value.Length
                    , "Pizza name should be between 1 and 15 symbols.");

                this.name = value;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == maxToppingCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{maxToppingCount}].");
            }

            this.toppings.Add(topping);
        }

        public double GetCalories()
        {
            return this.dough.GetCalories() + this.toppings.Sum(x => x.GetCalories());
        }
    }
}
