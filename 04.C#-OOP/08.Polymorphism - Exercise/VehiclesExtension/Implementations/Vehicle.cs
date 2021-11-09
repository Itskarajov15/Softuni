using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public virtual double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }
        public double TankCapacity
        {
            get => tankCapacity;
            set => tankCapacity = value;
        }
        public bool IsEmpty { get; set; }

        public void Drive(double distance)
        {
            if (this.FuelQuantity >= this.FuelConsumption * distance)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;

                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double litters)
        {
            ValidateLitters(litters);
            ValidateQuantity(litters);

            this.FuelQuantity += litters;
        }

        protected void ValidateQuantity(double litters)
        {
            if (this.FuelQuantity + litters > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {litters} fuel in the tank");
            }
        }

        protected void ValidateLitters(double litters)
        {
            if (litters <= 0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
