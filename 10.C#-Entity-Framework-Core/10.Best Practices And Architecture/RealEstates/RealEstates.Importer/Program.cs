using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Models;
using System.Text.Json;

namespace RealEstates.Importer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ImportJsonFile("imot.bg-houses-Sofia-raw-data-2021-03-18.json");
            Console.WriteLine();
            ImportJsonFile("imot.bg-raw-data-2021-03-18.json");
        }

        private static void ImportJsonFile(string fileName)
        {
            var dbContext = new ApplicationDbContext();
            IPropertiesService service = new PropertiesService(dbContext);

            var jsonText = File.ReadAllText(fileName);
            var properties = JsonSerializer.Deserialize<IEnumerable<PropertyAsJson>>(jsonText);

            foreach (var jsonProperty in properties)
            {
                service.Add(jsonProperty.District, jsonProperty.Floor, jsonProperty.Year, jsonProperty.TotalFloors, jsonProperty.Size, jsonProperty.YardSize,
                    jsonProperty.Type, jsonProperty.BuildingType, jsonProperty.Price);

                Console.WriteLine(".");
            }
        }
    }
}