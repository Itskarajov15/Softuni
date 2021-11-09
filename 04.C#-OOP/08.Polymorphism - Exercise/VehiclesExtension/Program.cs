using System;
using VehiclesExtension.Implementations;

namespace VehiclesExtension
{
    class Program
    {
        static void Main(string[] args)
        {
            var carData = ReadVehicleDataFromConsole();
            var truckData = ReadVehicleDataFromConsole();
            var busData = ReadVehicleDataFromConsole();

            var carFuelQuantity = double.Parse(carData[1]);
            var truckFuelQuantity = double.Parse(truckData[1]);
            var busFuelQuantity = double.Parse(busData[1]);

            var carFuelConsumption = double.Parse(carData[2]);
            var truckFuelConsumption = double.Parse(truckData[2]);
            var busFuelConsumption = double.Parse(busData[2]);

            var carTankCapacity = double.Parse(carData[3]);
            var truckTankCapacity = double.Parse(truckData[3]);
            var busTankCapacity = double.Parse(busData[3]);

            IVehicle car = new Car(carFuelQuantity, carFuelConsumption, carTankCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckFuelConsumption, truckTankCapacity);
            IVehicle bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommands; i++)
            {
                try
                {
                    var command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (command[0].Contains("Drive"))
                    {
                        if (command[1] == "Car")
                        {
                            car.Drive(double.Parse(command[2]));
                        }
                        else if (command[1] == "Truck")
                        {
                            truck.Drive(double.Parse(command[2]));
                        }
                        else if (command[1] == "Bus")
                        {
                            if (command[0] == "DriveEmpty")
                            {
                                bus.IsEmpty = true;
                                bus.Drive(double.Parse(command[2]));
                            }
                            else
                            {
                                bus.IsEmpty = false;
                                bus.Drive(double.Parse(command[2]));
                            }
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
                        else if (command[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(command[2]));
                        }
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static string[] ReadVehicleDataFromConsole()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
