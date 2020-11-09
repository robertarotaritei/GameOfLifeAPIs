using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;
using ActiveGamesAPI.Hubs;
using ActiveGamesAPI.Models;

namespace ActiveGamesAPI.Infrastructure
{
    public class SignalRGameProgressBroadcaster : IGameProgressBroadcaster
    {
        private async Task<HubConnection> OpenConnectionAsync()
        {
            var baseUrl = "http://localhost:3002";
            var connection = new HubConnectionBuilder().WithUrl(baseUrl + "/Progress").Build();
            await connection.StartAsync();

            return connection;
        }

        public async Task<GameState> UpdateGameAsync(GameState currentState)
        {
            await using var connection = await OpenConnectionAsync();
            await connection.InvokeAsync(nameof(GameProgressHub.UpdateGameAsync), currentState);

            return currentState;
        }

        public async Task<GameState> RunGameAsync(GameState initialState)
        {
            await using var connection = await OpenConnectionAsync();
            await connection.InvokeAsync(nameof(GameProgressHub.RunGameAsync), initialState);

            return initialState;
        }
    }
}
