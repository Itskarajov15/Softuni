namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCoachDto[]), new XmlRootAttribute("Coaches"));
            var sr = new StringReader(xmlString);
            var coaches = (ImportCoachDto[])xmlSerializer.Deserialize(sr);
            var sb = new StringBuilder();

            foreach (var item in coaches)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var coach = new Coach()
                {
                    Name = item.Name,
                    Nationality = item.Nationality
                };

                foreach (var footballer in item.Footballers)
                {
                    if (!IsValid(footballer))
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    var isContractStartDateParsed =
                        DateTime.TryParseExact(footballer.ContractStartDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var startDate);

                    var isContractEndDateParsed =
                        DateTime.TryParseExact(footballer.ContractEndDate,
                        "dd/MM/yyyy",
                        CultureInfo.InvariantCulture,
                        DateTimeStyles.None,
                        out var endDate);

                    if (!isContractStartDateParsed || !isContractEndDateParsed)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    if (startDate > endDate)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    coach.Footballers.Add(new Footballer
                    {
                        Name = footballer.Name,
                        PositionType = (PositionType)footballer.PositionType,
                        BestSkillType = (BestSkillType)footballer.BestSkillType,
                        ContractStartDate = startDate,
                        ContractEndDate = endDate
                    });
                }

                context.Coaches.Add(coach);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported coach - {coach.Name} with {coach.Footballers.Count} footballers.");
            }

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var teams = JsonConvert.DeserializeObject<ImportTeamDto[]>(jsonString);

            foreach (var item in teams)
            {
                if (!IsValid(item) || item.Trophies <= 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var team = new Team()
                {
                    Name = item.Name,
                    Nationality = item.Nationality,
                    Trophies = item.Trophies
                };

                foreach (var footballerId in item.Footballers.Distinct())
                {
                    var footballer = context.Footballers.FirstOrDefault(f => f.Id == footballerId);

                    if (footballer == null)
                    {
                        sb.AppendLine("Invalid data!");
                        continue;
                    }

                    team.TeamsFootballers.Add(new TeamFootballer
                    {
                        FootballerId = footballerId
                    });
                }

                context.Teams.Add(team);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported team - {team.Name} with {team.TeamsFootballers.Count} footballers.");
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
