using BasicKitchen.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasicKitchen
{
    public class Kitchen : IOrderable, ICostCalculatable, IMachinary
    {
        public List<string> Machines { get; set; }

        public void CalculateCost()
        {
            Console.WriteLine("Calculating cost...");
        }

        public void ListMachines()
        {
            Console.WriteLine("Machines");
        }

        public void OrderMeal(string mealName)
        {
            Console.WriteLine($"{mealName} ordered.");
        }
    }
}
