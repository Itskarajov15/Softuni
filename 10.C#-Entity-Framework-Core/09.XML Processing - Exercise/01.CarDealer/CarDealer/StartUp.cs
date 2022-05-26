using CarDealer.Data;
using System;
using System.IO;
using System.Xml;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var dbContext = new CarDealerContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            
        }
    }
}