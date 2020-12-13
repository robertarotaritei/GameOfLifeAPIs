using System.Threading.Tasks;
using ActiveGamesAPI.Models;

namespace ActiveGamesAPI.Infrastructure
{
    public interface IGameProgressBroadcaster
    {
        Task<GameInfo> SendGameInfo(GameState gameState);
    }
}
