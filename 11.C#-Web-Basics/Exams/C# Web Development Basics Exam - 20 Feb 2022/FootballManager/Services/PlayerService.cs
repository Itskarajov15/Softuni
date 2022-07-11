using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;

        public PlayerService(
            IRepository repo,
            IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public bool AddPlayer(AddPlayerViewModel model)
        {
            var url = model.ImageUrl;
            var isValid = validationService.ValidateModel(model);

            if (!isValid)
            {
                return isValid;
            }

            var player = new Player()
            {
                FullName = model.FullName,
                Description = model.Description,
                Endurance = model.Endurance,
                Position = model.Position,
                Speed = model.Speed,
                ImageUrl = model.ImageUrl
            };

            try
            {
                this.repo.Add(player);
                this.repo.SaveChanges();
                return isValid;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void AddPlayerToUserCollection(int playerId, string userId)
        {
            var usersPlayer = this.GetUserPlayer(userId, playerId);

            if (usersPlayer == null)
            {
                var userPlayer = new UserPlayer
                {
                    PlayerId = playerId,
                    UserId = userId,
                };

                try
                {
                    this.repo.Add(userPlayer);
                    this.repo.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        }

        private UserPlayer GetUserPlayer(string userId, int playerId)
            => this.repo.All<UserPlayer>()
                .Where(x => x.UserId == userId && x.PlayerId == playerId)
                .FirstOrDefault();

        public IEnumerable<Player> GetAllPlayers()
            => this.repo.All<Player>()
                    .ToList();

        public IEnumerable<Player> GetAllPlayersOfUser(string userId)
        {
            var playersIds = this.repo.All<UserPlayer>()
                    .Where(p => p.UserId == userId)
                    .Select(p => p.PlayerId)
                    .ToList();

            var players = new List<Player>();

            foreach (var id in playersIds)
            {
                var player = this.repo.All<Player>().Where(p => p.Id == id).FirstOrDefault();
                players.Add(player);
            }

            return players;
        }

        public void RemovePlayer(string userId, int playerId)
        {
            var userPlayer = this.repo.All<UserPlayer>()
                                  .Where(x => x.PlayerId == playerId && x.UserId == userId)
                                  .FirstOrDefault();

            try
            {
                this.repo.Remove(userPlayer);
                this.repo.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
    }
}