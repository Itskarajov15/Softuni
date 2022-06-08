namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;
    using System.Linq;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context
                .Theatres
                .ToList()
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Sum(t => t.Price),
                    Tickets = t.Tickets.ToList().Where(t => t.RowNumber >= 1 && t.RowNumber <= 5).Select(t => new
                    {
                        Price = t.Price,
                        RowNumber = t.RowNumber
                    })
                    .OrderByDescending(t => t.Price)
                    .ToList()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToList();

            var result = JsonConvert.SerializeObject(theatres, Formatting.Indented);

            return result;
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context
                .Plays
                .ToArray()
                .Where(p => p.Rating <= rating)
                .Select(p => new ExportPlayOutputModel
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString("c", CultureInfo.InvariantCulture),
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts
                        .ToArray()
                        .Where(c => c.IsMainCharacter == true)
                        .Select(c => new ExportActorOutputModel
                        {
                            FullName = c.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(c => c.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            var result = XmlConverter.Serialize(plays, "Plays");

            return result;
        }
    }
}
