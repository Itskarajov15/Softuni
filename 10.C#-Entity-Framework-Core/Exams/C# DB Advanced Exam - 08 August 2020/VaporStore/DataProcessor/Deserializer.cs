namespace VaporStore.DataProcessor
{
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public static class Deserializer
	{
		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
			var sb = new StringBuilder();
			var deserializedJson = JsonConvert.DeserializeObject<ImportGameInputModel[]>(jsonString);

            foreach (var item in deserializedJson)
            {
				if(!IsValid(item) ||
				   item.Tags.Count() <= 0)
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var isParsed = DateTime.TryParseExact(item.ReleaseDate,
					"yyyy-MM-dd",
					CultureInfo.InvariantCulture,
					DateTimeStyles.None,
					out DateTime releaseDate);

				var developer = context.Developers.FirstOrDefault(d => d.Name == item.Developer)
					?? new Developer { Name = item.Developer };

				var genre = context.Genres.FirstOrDefault(g => g.Name == item.Genre)
					?? new Genre { Name = item.Genre };

				var game = new Game
				{
					Name = item.Name,
					Genre = genre,
					Developer = developer,
					Price = item.Price,
					ReleaseDate = isParsed ? (DateTime?)releaseDate : null
				};

                foreach (var jsonTag in item.Tags)
                {
					var tag = context.Tags.FirstOrDefault(x => x.Name == jsonTag)
						?? new Tag { Name = jsonTag };

					game.GameTags.Add(new GameTag { Tag = tag });
                }

				context.Games.Add(game);
				context.SaveChanges();
				sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
            }

			return sb.ToString().TrimEnd();
		}

		public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
			throw new NotImplementedException();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			throw new NotImplementedException();
		}

		private static bool IsValid(object dto)
		{
			var validationContext = new ValidationContext(dto);
			var validationResult = new List<ValidationResult>();

			return Validator.TryValidateObject(dto, validationContext, validationResult, true);
		}
	}
}