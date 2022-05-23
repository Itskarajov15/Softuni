using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        static IMapper mapper;

        public static void Main(string[] args)
        {
            var carDealerContext = new CarDealerContext();
            carDealerContext.Database.EnsureDeleted();
            carDealerContext.Database.EnsureCreated();

            var json = File.ReadAllText("../../../Datasets/suppliers.json");

            var result = ImportSuppliers(carDealerContext, json);
            Console.WriteLine(result);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            InitializeMapper();

            var importSuppliersDto = JsonConvert.DeserializeObject<IEnumerable<ImportSupplierInputModel>>(inputJson);

            var suppliers = mapper.Map<IEnumerable<Supplier>>(importSuppliersDto);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
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