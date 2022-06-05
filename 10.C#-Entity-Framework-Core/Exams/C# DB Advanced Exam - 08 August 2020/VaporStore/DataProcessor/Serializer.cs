namespace VaporStore.DataProcessor
{
	using System;
    using System.Globalization;
    using System.Linq;
    using Data;
    using Newtonsoft.Json;
    using VaporStore.Data.Models.Enums;
    using VaporStore.DataProcessor.Dto.Export;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var genres = context.Genres.ToList()
				.Where(g => genreNames.Contains(g.Name))
				.Select(g => new
				{
					Id = g.Id,
					Genre = g.Name,
					Games = g.Games.Select(x => new 
					{
						Id = x.Id,
						Title = x.Name,
						Developer = x.Developer.Name,
						Tags = string.Join(", ", x.GameTags.Select(gt => gt.Tag.Name)),
						Players = x.Purchases.Count()
					})
					.Where(g => g.Players > 0)
					.OrderByDescending(x => x.Players)
					.ThenBy(x => x.Id)
					.ToList(),
					TotalPlayers = g.Games.Sum(x => x.Purchases.Count())
				})
				.OrderByDescending(g => g.TotalPlayers)
				.ThenBy(g => g.Id);

			var result = JsonConvert.SerializeObject(genres, Formatting.Indented);

			return result;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var users = context.Users
				.ToList()
				.Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == storeType)))
				.Select(x => new ExportUserOutputModel
				{
					Username = x.Username,
					Purchases = x.Cards.SelectMany(c => c.Purchases)
					.Where(p => p.Type.ToString() == storeType)
					.Select(p => new ExportPurchaseOutputModel
					{
						Card = p.Card.Number,
						Cvc = p.Card.Cvc,
						Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
						Game = new ExportGamePurchaseOutputModel
						{
							Title = p.Game.Name,
							Price = p.Game.Price,
							Genre = p.Game.Genre.Name
						}
					})
					.OrderBy(p => p.Date)
					.ToArray(),
					TotalSpent = x.Cards.Sum(c => c.Purchases.Where(p => p.Type.ToString() == storeType).Sum(p => p.Game.Price))
				})
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToList();

			var result = XmlConverter.Serialize(users, "Users");

			return result;
		}
	}
}