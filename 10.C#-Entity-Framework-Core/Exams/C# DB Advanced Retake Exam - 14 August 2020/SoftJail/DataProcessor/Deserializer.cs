namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var departmentsCells = JsonConvert.DeserializeObject<IEnumerable<DepartmentCellInputModel>>(jsonString);
            var departments = new List<Department>();

            foreach (var departmentCell in departmentsCells)
            {
                if (!IsValid(departmentCell) ||
                    !departmentCell.Cells.All(IsValid) ||
                    !departmentCell.Cells.Any())
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var department = new Department
                {
                    Name = departmentCell.Name,
                    Cells = departmentCell.Cells.Select(dp => new Cell
                    {
                        CellNumber = dp.CellNumber,
                        HasWindow = dp.HasWindow
                    })
                    .ToList()
                };

                departments.Add(department);
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var prisonersMails = JsonConvert.DeserializeObject<IEnumerable<PrisonerMailInputModel>>(jsonString);
            var prisoners = new List<Prisoner>();
            var sb = new StringBuilder();

            foreach (var prisonerMail in prisonersMails)
            {
                if (!IsValid(prisonerMail) ||
                    !prisonerMail.Mails.All(IsValid))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var isValidReleaseDate = DateTime.TryParseExact(
                    prisonerMail.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releaseDate);

                var prisoner = new Prisoner
                {
                    FullName = prisonerMail.FullName,
                    Nickname = prisonerMail.Nickname,
                    Age = prisonerMail.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerMail.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = isValidReleaseDate ? (DateTime?)releaseDate : null,
                    Bail = prisonerMail.Bail,
                    CellId = prisonerMail.CellId,
                    Mails = prisonerMail.Mails.Select(x => new Mail
                    {
                        Description = x.Description,
                        Sender = x.Sender,
                        Address = x.Address
                    })
                    .ToList()
                };

                prisoners.Add(prisoner);
                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var officerPrisoners = XmlConverter.Deserializer<OfficerPrisonerInputModel>(xmlString, "Officers");
            var officers = new List<Officer>();
            var sb = new StringBuilder();

            foreach (var item in officerPrisoners)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                var officer = new Officer
                {
                    FullName = item.Name,
                    Salary = item.Salary,
                    Position = Enum.Parse<Position>(item.Position),
                    Weapon = Enum.Parse<Weapon>(item.Weapon),
                    DepartmentId = item.DepartmentId,
                    OfficerPrisoners = item.Prisoners.Select(x => new OfficerPrisoner
                    {
                        PrisonerId = x.Id
                    })
                    .ToList()
                };

                officers.Add(officer);
                sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}