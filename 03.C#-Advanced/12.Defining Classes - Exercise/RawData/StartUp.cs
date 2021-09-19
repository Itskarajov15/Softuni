using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                var currEngine = new Engine(engineSpeed, enginePower);
                var currCargo = new Cargo(cargoWeight, cargoType);
                var currTires = new Tire[4]
                {
                    new Tire(double.Parse(carInfo[5]), int.Parse(carInfo[6])),
                    new Tire(double.Parse(carInfo[7]), int.Parse(carInfo[8])),
                    new Tire(double.Parse(carInfo[9]), int.Parse(carInfo[10])),
                    new Tire(double.Parse(carInfo[11]), int.Parse(carInfo[12]))
                };

                var currCar = new Car(model, currEngine, currCargo, currTires);

                cars.Add(currCar);
            }

            string type = Console.ReadLine();

            var filteredCars = new List<Car>();

            if (type == "fragile")
            {
                foreach (var car in cars)
                {
                    bool isValid = false;

                    foreach (var tire in car.Tires)
                    {
                        if (tire.Pressure < 1)
                        {
                            isValid = true;
                        }
                    }

                    if (isValid)
                    {
                        filteredCars.Add(car);
                    }
                }

                filteredCars = filteredCars
                    .Where(x => x.Cargo.Type == "fragile")
                    .ToList();
            }
            else if (type == "flammable")
            {
                filteredCars = cars
                    .Where(x => x.Cargo.Type == "flammable")
                    .Where(x => x.Engine.Power > 250)
                    .ToList();
            }

            foreach (var car in filteredCars)
            {
                Console.WriteLine(car.Model);
            }
        }
    }
}