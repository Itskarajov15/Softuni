using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels.Players;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(
            Request request, 
            IPlayerService playerService) 
            : base(request)
        {
            this.playerService = playerService;
        }

        public Response All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var players = this.playerService.GetAllPlayers();

            var model = new
            {
                players = players,
                IsAuthenticated = true
            };

            return this.View(model);
        }

        public Response Collection()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var userId = User.Id;

            var collection = this.playerService.GetAllPlayersOfUser(userId);

            var model = new
            {
                players = collection,
                IsAuthenticated = true
            };

            return this.View(model);
        }

        public Response Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return this.View(new { IsAuthenticated = true });
        }

        [HttpPost]
        public Response Add(AddPlayerViewModel model)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            var isValid = this.playerService.AddPlayer(model);

            if (!isValid)
            {
                return Redirect("/Players/Add");
            }

            return Redirect("/Players/All");
        }

        public Response AddToCollection(int playerId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var userId = User.Id;

            this.playerService.AddPlayerToUserCollection(playerId, userId);

            return Redirect("/Players/All");
        }

        public Response RemoveFromCollection(int playerId)
        {
            if (!this.User.IsAuthenticated)
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.User.Id;

            this.playerService.RemovePlayer(userId, playerId);

            return Redirect("/Players/Collection");
        }
    }
}