using System;

namespace BasicKitchen
{
    class Program
    {
        static void Main(string[] args)
        {
            var kitchen = new Kitchen();

            var waiter = new Waiter();

            var ceo = new CEO();

            var tech = new Tech();

            waiter.Kitchen.OrderMeal("random meal");
            ceo.Kitchen.CalculateCost();
            tech.Kitchen.ListMachines();
        }
    }
}
