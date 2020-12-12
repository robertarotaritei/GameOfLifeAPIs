using ActiveGamesAPI.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ActiveGamesAPI.Hubs
{
    public class GameProgressHub: Hub
    {
        public async Task SendGameInfo(GameInfo gameInfo)
        {
            await Clients.Clients(gameInfo.ReactConnectionId).SendAsync("GameInfoSent", gameInfo.Info);
        }

        public async Task RunGameAsync(GameState initialState)
        {
            await Clients.AllExcept(initialState.ReactConnectionId).SendAsync("GameInitiated", initialState);
        }

        public string GetConnectionId() => Context.ConnectionId;
    }
}
