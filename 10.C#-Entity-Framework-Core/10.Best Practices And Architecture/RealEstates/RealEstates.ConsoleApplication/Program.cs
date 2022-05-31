using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;

namespace RealEstates.ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.WriteLine("Choose an option.");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("0. EXIT");
                bool parsed = int.TryParse(Console.ReadLine(), out int option);

                if(parsed && option == 0)
                {
                    break;
                }

                if(parsed && option >= 1 && option <= 2)
                {
                    switch (option)
                    {
                        case 1: 
                            PropertySearch(db);
                            break;
                        case 2: 
                            MostExpensiveDistricts(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void MostExpensiveDistricts(ApplicationDbContext db)
        {
            Console.WriteLine("Count: ");
            int count = int.Parse(Console.ReadLine());

            IDistrictsService service;
            var districts = service.GetMostExpensiveDistricts(count);

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name}; {district.AveragePricePerSquareMeter}; {district.PropertiesCount};");
            }
        }

        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.WriteLine("Min price:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Min price:");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Min price:");
            int minSize = int.Parse(Console.ReadLine());
            Console.WriteLine("Min price:");
            int maxSize = int.Parse(Console.ReadLine());

            IPropertiesService service = new PropertiesService(db);

            var properties = service.Search(minPrice, maxPrice, minSize, maxSize);

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.DistrictName}; {property.BuildingType}; {property.PropertyType}; {property.Price} => {property.Size}");
            }
        }
    }
}