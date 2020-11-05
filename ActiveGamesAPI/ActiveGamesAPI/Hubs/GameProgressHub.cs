using ActiveGamesAPI.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ActiveGamesAPI.Hubs
{
    public class GameProgressHub: Hub
    {
        public async Task UpdateGameAsync(GameState currentState)
        {
            currentState.RunnerConnectionId = Context.ConnectionId;
            await Clients.Clients(currentState.ReactConnectionId).SendAsync("GameProgressed", currentState);
        }

        public async Task RunGameAsync(GameState initialState)
        {
            await Clients.AllExcept(initialState.ReactConnectionId).SendAsync("GameInitiated", initialState);
        }

        public string GetConnectionId() => Context.ConnectionId;
    }
}
