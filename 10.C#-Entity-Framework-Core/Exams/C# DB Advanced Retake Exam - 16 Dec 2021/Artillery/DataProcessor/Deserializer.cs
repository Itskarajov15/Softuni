namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage =
                "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var countries = XmlConverter.Deserializer<ImportCountryInputModel>(xmlString, "Countries");
            var sb = new StringBuilder();

            foreach (var item in countries)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country
                {
                    CountryName = item.CountryName,
                    ArmySize = item.ArmySize
                };

                context.Countries.Add(country);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var manufacturers = XmlConverter.Deserializer<ImportManufacturerInputModel>(xmlString, "Manufacturers");
            var sb = new StringBuilder();

            foreach (var item in manufacturers)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = context.Manufacturers.FirstOrDefault(m => m.ManufacturerName == item.ManufacturerName);

                if (manufacturer != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var newManufacturer = new Manufacturer
                {
                    ManufacturerName = item.ManufacturerName,
                    Founded = item.Founded
                };

                var splitted = item.Founded.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                splitted.RemoveRange(0, splitted.Count - 2);

                context.Manufacturers.Add(newManufacturer);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportManufacturer, newManufacturer.ManufacturerName, String.Join(", ", splitted)));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var shells = XmlConverter.Deserializer<ImportShellInputModel>(xmlString, "Shells");
            var sb = new StringBuilder();

            foreach (var item in shells)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell
                {
                    ShellWeight = item.ShellWeight,
                    Caliber = item.Caliber,
                };

                context.Shells.Add(shell);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var guns = JsonConvert.DeserializeObject<IEnumerable<ImportGunInputModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var item in guns)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
                {
                    ManufacturerId = item.ManufacturerId,
                    GunWeight = item.GunWeight,
                    BarrelLength = item.BarrelLength,
                    NumberBuild = item.NumberBuild,
                    Range = item.Range,
                    GunType = Enum.Parse<GunType>(item.GunType),
                    ShellId = item.ShellId
                };

                foreach (var country in item.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun
                    {
                        CountryId = country.Id
                    });
                }

                context.Guns.Add(gun);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
