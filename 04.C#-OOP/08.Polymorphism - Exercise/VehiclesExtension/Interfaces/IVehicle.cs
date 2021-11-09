using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }

        public double FuelConsumption { get; set; }

        public double TankCapacity { get; }

        public bool IsEmpty { get; set; }

        void Drive(double distance);

        void Refuel(double litters);
    }
}
