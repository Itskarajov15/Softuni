using System;

namespace Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            var carData = ReadVehicleDataFromConsole();
            var truckData = ReadVehicleDataFromConsole();

            IVehicle car = new Car(double.Parse(carData[1]), double.Parse(carData[2]));
            IVehicle truck = new Truck(double.Parse(truckData[1]), double.Parse(truckData[2]));

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Drive")
                {
                    if (command[1] == "Car")
                    {
                        car.Drive(double.Parse(command[2]));
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Drive(double.Parse(command[2]));
                    }
                }
                else if (command[0] == "Refuel")
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(double.Parse(command[2]));
                    }
                    else if (command[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(command[2]));
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static string[] ReadVehicleDataFromConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
