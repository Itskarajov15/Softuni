using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[]
            {
                new Tire (2002, 505.5),
                new Tire (2020, 600.4),
                new Tire (2021, 600.6)
            };

            var engine = new Engine(505, 1000.2);
        }
    }
}
