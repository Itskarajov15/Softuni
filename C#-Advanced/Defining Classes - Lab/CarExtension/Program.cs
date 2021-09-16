using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "Mercedes";
            car.Model = "S class";
            car.Year = 2021;
            car.FuelQuantity = 200;
            car.FuelConsumption = 8.2;

            car.Drive(200);

            Console.WriteLine(car.WhoAmI());
        }
    }
}
