using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public class Truck : Vehicle
    {
        private const double airConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + airConditionerConsumption, tankCapacity)
        {
        }

        public override void Refuel(double litters)
        {
            ValidateLitters(litters);
            ValidateQuantity(litters);

            litters *= 0.95;

            base.Refuel(litters);
        }
    }
}
