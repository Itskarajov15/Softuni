using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car
            {
                Make = "Mercedes",
                Model = "S class",
                Year = 2021,
            };

            Console.WriteLine($"Make: {car.Make}, Model: {car.Model}, Year: {car.Year}");
        }
    }
}
