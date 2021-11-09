using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double airConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + airConditionerConsumption)
        {
        }

        public override void Refuel(double litters)
        {
            litters *= 0.95;

            base.Refuel(litters);
        }
    }
}
