using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using ActiveGamesAPI.Hubs;
using ActiveGamesAPI.Models;

namespace ActiveGamesAPI.Infrastructure
{
    public class SignalRGameProgressBroadcaster : IGameProgressBroadcaster
    {
        readonly string BaseUrl;
        private GameStateCalculator Calculator;
        public SignalRGameProgressBroadcaster(string url)
        {
            BaseUrl = url;
            Calculator = new GameStateCalculator();
        }

        private async Task<HubConnection> OpenConnectionAsync()
        {
            var connection = new HubConnectionBuilder().WithUrl(BaseUrl + "/Progress").Build();
            await connection.StartAsync();

            return connection;
        }

        public async Task<GameInfo> SendGameInfo(GameState initialState)
        {
            var gameInfo = new GameInfo()
            {
                Info = Calculator.CalculateGameType(initialState.Generation),
                ReactConnectionId = initialState.ReactConnectionId
            };

            await using var connection = await OpenConnectionAsync();
            await connection.InvokeAsync(nameof(GameProgressHub.SendGameInfo), gameInfo);

            return gameInfo;
        }
    }
}
