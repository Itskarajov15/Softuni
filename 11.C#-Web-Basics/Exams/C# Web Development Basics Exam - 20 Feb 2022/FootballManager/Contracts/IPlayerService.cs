using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        IEnumerable<Player> GetAllPlayers();

        IEnumerable<Player> GetAllPlayersOfUser(string userId);

        bool AddPlayer(AddPlayerViewModel player);

        void AddPlayerToUserCollection(int playerId, string userId);

        void RemovePlayer(string userId, int playerId);
    }
}