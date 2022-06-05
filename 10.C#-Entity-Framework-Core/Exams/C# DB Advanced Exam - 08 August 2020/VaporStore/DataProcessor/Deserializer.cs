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
    using VaporStore.Data.Models.Enums;
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
					ReleaseDate = item.ReleaseDate.Value
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
			var sb = new StringBuilder();
			var users = JsonConvert.DeserializeObject<IEnumerable<ImportUserInputModel>>(jsonString);

            foreach (var user in users)
            {
				if (!IsValid(user)
					|| !user.Cards.Any(IsValid))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				var newUser = new User
				{
					FullName = user.FullName,
					Username = user.Username,
					Email = user.Email,
					Age = user.Age,
					Cards = user.Cards.Select(c => new Card
					{
						Number = c.Number,
						Cvc = c.CVC,
						Type = c.Type.Value
					})
					.ToList()
				};

				context.Users.Add(newUser);
				context.SaveChanges();
				sb.AppendLine($"Imported {newUser.Username} with {newUser.Cards.Count()} cards");
            }

			return sb.ToString().TrimEnd();
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
			var sb = new StringBuilder();
			var purchases = XmlConverter.Deserializer<ImportPurchaseInputModel>(xmlString, "Purchases");

            foreach (var purchase in purchases)
            {
				if (!IsValid(purchase))
                {
					sb.AppendLine("Invalid Data");
					continue;
                }

				bool isParsed = DateTime.TryParseExact(purchase.Date,
					"dd/MM/yyyy HH:mm",
					CultureInfo.InvariantCulture,
					DateTimeStyles.None,
					out DateTime date);

				if (!isParsed)
                {
					sb.AppendLine("Invalid Data");
					continue;
				}

				var newPurchase = new Purchase
				{
					Date = date,
					Type = purchase.Type.Value,
					ProductKey = purchase.Key
				};

				newPurchase.Card = 
					context.Cards.FirstOrDefault(c => c.Number == purchase.Card);
				newPurchase.Game = 
					context.Games.FirstOrDefault(g => g.Name == purchase.Title);

				context.Purchases.Add(newPurchase);
				context.SaveChanges();

				var username = context.Users.Where(u => u.Id == newPurchase.Card.UserId)
					.Select(u => u.Username)
					.FirstOrDefault();

				sb.AppendLine($"Imported {newPurchase.Game.Name} for {username}");
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