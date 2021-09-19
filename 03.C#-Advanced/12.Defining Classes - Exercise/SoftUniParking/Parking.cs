using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            if (cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count >= capacity)
            {
                return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string registration)
        {
            if (cars.Any(x => x.RegistrationNumber == registration))
            {
                cars.Remove(cars.Find(x => x.RegistrationNumber == registration));
                return $"Successfully removed {registration}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string registration)
        {
            var neededCar = cars.Find(x => x.RegistrationNumber == registration);

            return neededCar;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            this.cars = this.cars
                .Where(c => !registrationNumbers.Contains(c.RegistrationNumber))
                .ToList();
        }
    }
}
