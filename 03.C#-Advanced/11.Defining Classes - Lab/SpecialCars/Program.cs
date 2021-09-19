using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new List<Tire[]>();
            var engines = new List<Engine>();
            var cars = new List<Car>();

            string command = Console.ReadLine();

            while (command != "No more tires")
            {
                List<double> tiresInfo = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList();

                var newTire = new Tire[4]
                {
                    new Tire((int)tiresInfo[0], tiresInfo[1]),
                    new Tire((int)tiresInfo[2], tiresInfo[3]),
                    new Tire((int)tiresInfo[4], tiresInfo[5]),
                    new Tire((int)tiresInfo[6], tiresInfo[7])
                };

                tires.Add(newTire);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Engines done")
            {
                List<double> engine = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToList();

                int horsePower = (int)engine[0];
                double cubicCapacity = engine[1];

                engines.Add(new Engine(horsePower, cubicCapacity));

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Show special")
            {
                List<string> car = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).
                    ToList();

                string make = car[0];
                string model = car[1];
                int year = int.Parse(car[2]);
                double fuelQuantity = double.Parse(car[3]);
                double fuelConsumption = double.Parse(car[4]);
                int engineIndex = int.Parse(car[5]);
                int tiresIndex = int.Parse(car[6]);

                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption,
                    engines[engineIndex], tires[tiresIndex]));

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                double pressure = 0;

                if (car.Year >= 2017 && car.Engine.HorsePower > 330)
                {
                    foreach (var currPressure in car.Tires)
                    {
                        pressure += currPressure.Pressure;
                    }

                    if (pressure >= 9 && pressure <= 10)
                    {
                        car.Drive(20);

                        Console.WriteLine(car.WhoAmI());
                    }
                }
            }
        }
    }
}
