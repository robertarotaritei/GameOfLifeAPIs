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

        public string GetConnectionId() => Context.ConnectionId;
    }
}
