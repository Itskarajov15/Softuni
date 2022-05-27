using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
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

            var supplierResult = ImportSuppliers(dbContext, inputSuppliersXml);
            var partResult = ImportParts(dbContext, inputPartsXml);
            Console.WriteLine(partResult);
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