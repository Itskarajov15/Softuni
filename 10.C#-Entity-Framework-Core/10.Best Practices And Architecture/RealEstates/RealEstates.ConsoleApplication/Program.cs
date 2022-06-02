using Microsoft.EntityFrameworkCore;
using RealEstates.Data;
using RealEstates.Services;
using RealEstates.Services.Models;
using System.Text;
using System.Xml.Serialization;

namespace RealEstates.ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            var db = new ApplicationDbContext();
            db.Database.Migrate();

            while (true)
            {
                Console.WriteLine("Choose an option.");
                Console.WriteLine("1. Property search");
                Console.WriteLine("2. Most expensive districts");
                Console.WriteLine("3. Average price per square meter");
                Console.WriteLine("4. Add tag");
                Console.WriteLine("5. Bulk tags");
                Console.WriteLine("6. Property full info");
                Console.WriteLine("0. EXIT");
                bool parsed = int.TryParse(Console.ReadLine(), out int option);

                if(parsed && option == 0)
                {
                    break;
                }

                if(parsed && option >= 1 && option <= 6)
                {
                    switch (option)
                    {
                        case 1: 
                            PropertySearch(db);
                            break;
                        case 2: 
                            MostExpensiveDistricts(db);
                            break;
                        case 3:
                            AveragePricePerSquareMeter(db);
                            break;
                        case 4:
                            AddTag(db);
                            break;
                        case 5:
                            BulkTagToProperties(db);
                            break;
                        case 6:
                            PropertyFullInfo(db);
                            break;
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void PropertyFullInfo(ApplicationDbContext db)
        {
            Console.Write("Count of properties: ");
            int count = int.Parse(Console.ReadLine());
            IPropertiesService propertiesService = new PropertiesService(db);
            var properties = propertiesService.GetFullData(count).ToArray();
            var xmlSerializer = new XmlSerializer(typeof(PropertyInfoFullDataDto[]), new XmlRootAttribute("Property"));
            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, properties);
            Console.WriteLine(stringWriter.ToString().TrimEnd());
        }

        private static void BulkTagToProperties(ApplicationDbContext db)
        {
            Console.WriteLine("Bulk operation started!");
            IPropertiesService propertiesService = new PropertiesService(db);
            ITagService tagService = new TagService(db, propertiesService);
            tagService.BulkTagToProperties();
            Console.WriteLine("Bulk operation finished!");
        }

        private static void AddTag(ApplicationDbContext db)
        {
            IPropertiesService propertiesService = new PropertiesService(db);
            ITagService tagService = new TagService(db, propertiesService);

            Console.Write("Insert tag name: ");
            string tagName = Console.ReadLine();
            Console.Write("Insert importance (Optional): ");
            bool isParsed = int.TryParse(Console.ReadLine(), out int tagImportance);

            int? importance = isParsed ? tagImportance : null;

            tagService.Add(tagName, importance);
        }

        private static void AveragePricePerSquareMeter(ApplicationDbContext db)
        {
            IPropertiesService service = new PropertiesService(db);
            Console.WriteLine($"Average price per square meter: {service.AveragePricePerSquareMeter():f2}");
        }

        private static void MostExpensiveDistricts(ApplicationDbContext db)
        {
            Console.Write("Count: ");
            int count = int.Parse(Console.ReadLine());

            IDistrictsService service = new DistrictService(db);
            var districts = service.GetMostExpensiveDistricts(count);

            foreach (var district in districts)
            {
                Console.WriteLine($"{district.Name}; {district.AveragePricePerSquareMeter:f2}; {district.PropertiesCount};");
            }
        }

        private static void PropertySearch(ApplicationDbContext db)
        {
            Console.Write("Min price:");
            int minPrice = int.Parse(Console.ReadLine());
            Console.Write("Max price:");
            int maxPrice = int.Parse(Console.ReadLine());
            Console.Write("Min size:");
            int minSize = int.Parse(Console.ReadLine());
            Console.Write("Max size:");
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