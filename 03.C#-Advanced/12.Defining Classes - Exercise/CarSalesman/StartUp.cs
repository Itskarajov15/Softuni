using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();

            int numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                var engineInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                engines.Add(CreateNewEngine(engineInfo));
            }

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                cars.Add(CreateNewCar(carInfo, engines));
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        static Car CreateNewCar(string[] carInfo, List<Engine> engines)
        {
            string model = carInfo[0];
            string engineModel = carInfo[1];

            Engine engine = engines.Find(x => x.Model == engineModel);

            var newCar = new Car(model, engine);

            if (carInfo.Length == 4)
            {
                newCar.Weight = int.Parse(carInfo[2]);
                newCar.Color = carInfo[3];
            }
            else if (carInfo.Length == 3)
            {
                bool isDigit = int.TryParse(carInfo[2], out int weight);

                if (isDigit)
                {
                    newCar.Weight = weight;
                }
                else
                {
                    newCar.Color = carInfo[2];
                }
            }

            return newCar;
        }

        static Engine CreateNewEngine(string[] engineInfo)
        {
            string model = engineInfo[0];
            int power = int.Parse(engineInfo[1]);

            var newEngine = new Engine(model, power);

            if (engineInfo.Length == 4)
            {
                newEngine.Displacement = int.Parse(engineInfo[2]);
                newEngine.Efficiency = engineInfo[3];
            }
            else if (engineInfo.Length == 3)
            {
                bool isDigit = int.TryParse(engineInfo[2], out int displacement);

                if (isDigit)
                {
                    newEngine.Displacement = displacement;
                }
                else
                {
                    newEngine.Efficiency = engineInfo[2];
                }
            }

            return newEngine;
        }
    }
}
