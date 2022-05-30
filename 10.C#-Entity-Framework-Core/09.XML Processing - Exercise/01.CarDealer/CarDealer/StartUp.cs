using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            var inputSuppliersXml = File.ReadAllText("Datasets/suppliers.xml");
            var inputPartsXml = File.ReadAllText("Datasets/parts.xml");
            var inputCarsXml = File.ReadAllText("Datasets/cars.xml");
            var inputCustomersXml = File.ReadAllText("Datasets/customers.xml");
            var inputSalesXml = File.ReadAllText("Datasets/sales.xml");

            var suppliersResult = ImportSuppliers(dbContext, inputSuppliersXml);
            var partsResult = ImportParts(dbContext, inputPartsXml);
            var carsResult = ImportCars(dbContext, inputCarsXml);
            var customersResult = ImportCustomers(dbContext, inputCustomersXml);
            var salesResult = ImportSales(dbContext, inputSalesXml);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var xmlSerializer = new XmlSerializer(typeof(List<ImportSupplierDto>), new XmlRootAttribute("Suppliers"));

            using var stringReader = new StringReader(inputXml);

            var suppliersDtos = (List<ImportSupplierDto>)xmlSerializer.Deserialize(stringReader);

            var suppliers = mapper.Map<List<Supplier>>(suppliersDtos);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(List<ImportPartDto>), new XmlRootAttribute("Parts"));
            using var stringReader = new StringReader(inputXml);

            var partsDtos = (List<ImportPartDto>)serializer.Deserialize(stringReader);

            var parts = mapper.Map<List<Part>>(partsDtos);

            parts = parts.
                Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToList();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(List<ImportCarDto>), new XmlRootAttribute("Cars"));
            using var stringReader = new StringReader(inputXml);

            var carDtos = (List<ImportCarDto>)serializer.Deserialize(stringReader);
            var allParts = context.Parts.Select(p => p.Id).ToList();

            var cars = carDtos
                .Select(x => new Car
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TraveledDistance,
                    PartCars = x.CarPartsInputModel.Select(x => x.Id)
                    .Distinct()
                    .Intersect(allParts)
                    .Select(pc => new PartCar
                    {
                        PartId = pc
                    })
                    .ToList()
                })
                .ToList();

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(List<ImportCustomerDto>), new XmlRootAttribute("Customers"));
            using var stringReader = new StringReader(inputXml);

            var customersDtos = (List<ImportCustomerDto>)serializer.Deserialize(stringReader);
            var customers = mapper.Map<List<Customer>>(customersDtos);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            InitializeMapper();

            var serializer = new XmlSerializer(typeof(List<ImportSaleDto>), new XmlRootAttribute("Sales"));
            using var stringReader = new StringReader(inputXml);

            var salesDtos = (List<ImportSaleDto>)serializer.Deserialize(stringReader);

            var sales = mapper.Map<List<Sale>>(salesDtos)
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .ToList();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .Select(c => new ExportCarDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToList();

            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var xmlSerializer = new XmlSerializer(typeof(List<ExportCarDto>), new XmlRootAttribute("cars"));

            var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, cars, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportBmwDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportBmwDto>), new XmlRootAttribute("cars"));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, cars, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportSupplierDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportSupplierDto>), new XmlRootAttribute("suppliers"));

            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            serializer.Serialize(stringWriter, suppliers, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new ExportCarsWithParts
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(pc => new CarPartInfoOutputModel
                        {
                            Name = pc.Part.Name,
                            Price = pc.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportCarsWithParts>), new XmlRootAttribute("cars"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            serializer.Serialize(stringWriter, cars, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(c => c.Sales.Count() >= 1)
                .Select(c => new ExportCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Select(s => s.Car).SelectMany(x => x.PartCars).Sum(x => x.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportCustomerDto>), new XmlRootAttribute("customers"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            serializer.Serialize(stringWriter, customers, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new ExportSalesDto
                {
                    Car = new ExportCarForSaleDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartCars
                                .Sum(x => x.Part.Price) - s.Discount * s.Car.PartCars
                                .Sum(x => x.Part.Price) / 100
                })
                .ToList();

            var serializer = new XmlSerializer(typeof(List<ExportSalesDto>), new XmlRootAttribute("sales"));
            var stringWriter = new StringWriter();
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            serializer.Serialize(stringWriter, sales, namespaces);

            return stringWriter.ToString().TrimEnd();
        }

        public static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            });

            mapper = config.CreateMapper();
        }
    }
}