
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System;
    using System.Linq;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var shells = context
                .Shells
                .ToList()
                .Where(s => s.ShellWeight > shellWeight)
                .Select(s => new
                {
                    ShellWeight = s.ShellWeight,
                    Caliber = s.Caliber,
                    Guns = s.Guns
                            .Where(g => g.GunType.ToString() == "AntiAircraftGun")
                            .Select(g => new
                            {
                                GunType = g.GunType.ToString(),
                                GunWeight = g.GunWeight,
                                BarrelLength = g.BarrelLength,
                                Range = g.Range > 3000 ? "Long-range" : "Regular range"
                            })
                            .OrderByDescending(g => g.GunWeight)
                            .ToList()
                })
                .OrderBy(s => s.ShellWeight)
                .ToList();

            var result = JsonConvert.SerializeObject(shells, Formatting.Indented);

            return result;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            var guns = context
                .Guns
                .Where(g => g.Manufacturer.ManufacturerName == manufacturer)
                .Select(g => new ExportGunOutputModel
                {
                    Manufacturer = g.Manufacturer.ManufacturerName,
                    GunType = g.GunType.ToString(),
                    BarrelLength = g.BarrelLength,
                    GunWeight = g.GunWeight,
                    Range = g.Range,
                    Countries = g.CountriesGuns
                            .Where(cg => cg.Country.ArmySize > 4500000)
                            .Select(cg => new ExportCountryOutputModel
                            {
                                Country = cg.Country.CountryName,
                                ArmySize = cg.Country.ArmySize
                            })
                            .OrderBy(cg => cg.ArmySize)
                            .ToArray()
                })
                .OrderBy(g => g.BarrelLength)
                .ToList();

            var result = XmlConverter.Serialize(guns, "Guns");

            return result;
        }
    }
}
