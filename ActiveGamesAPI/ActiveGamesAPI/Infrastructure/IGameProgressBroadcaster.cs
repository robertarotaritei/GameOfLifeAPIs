using System.Threading.Tasks;
using ActiveGamesAPI.Models;

namespace ActiveGamesAPI.Infrastructure
{
    public interface IGameProgressBroadcaster
    {
        Task<GameState> UpdateGameAsync(GameState currentState);

        Task<GameState> RunGameAsync(GameState initialState);
    }
}
