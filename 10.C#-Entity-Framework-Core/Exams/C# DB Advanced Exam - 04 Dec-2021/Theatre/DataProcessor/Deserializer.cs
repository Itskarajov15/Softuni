namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var plays = XmlConverter.Deserializer<ImportPlayInputModel>(xmlString, "Plays");
            var sb = new StringBuilder();

            foreach (var item in plays)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isDurationParsed = TimeSpan.TryParseExact(
                    item.Duration.ToString(),
                    "c",
                    CultureInfo.InvariantCulture,
                    out TimeSpan result);

                if (!isDurationParsed)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (result.Hours < 1)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play
                {
                    Title = item.Title,
                    Duration = result,
                    Rating = item.Rating,
                    Genre = Enum.Parse<Genre>(item.Genre),
                    Description = item.Description,
                    Screenwriter = item.Screenwriter
                };

                context.Plays.Add(play);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var casts = XmlConverter.Deserializer<ImportCastInputModel>(xmlString, "Casts");
            var sb = new StringBuilder();

            foreach (var item in casts)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast
                {
                    FullName = item.FullName,
                    IsMainCharacter = item.IsMainCharacter,
                    PhoneNumber = item.PhoneNumber,
                    PlayId = item.PlayId,
                };

                context.Casts.Add(cast);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, cast.IsMainCharacter ? "main" : "lesser"));
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var theaters = JsonConvert.DeserializeObject<IEnumerable<ImportTheatreInputModel>>(jsonString);
            var sb = new StringBuilder();

            foreach (var item in theaters)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre
                {
                    Name = item.Name,
                    NumberOfHalls = item.NumberOfHalls,
                    Director = item.Director
                };

                foreach (var ticket in item.Tickets)
                {
                    if (!IsValid(ticket))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var newTicket = new Ticket
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    };

                    theatre.Tickets.Add(newTicket);
                }

                context.Theatres.Add(theatre);
                context.SaveChanges();
                sb.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count));
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
