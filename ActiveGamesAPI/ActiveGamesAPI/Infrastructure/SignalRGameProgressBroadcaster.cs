using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActiveGamesAPI.Hubs;
using ActiveGamesAPI.Models;

namespace ActiveGamesAPI.Infrastructure
{
    public class SignalRGameProgressBroadcaster : IGameProgressBroadcaster
    {
        private async Task<HubConnection> OpenConnectionAsync()
        {
            var connection = new HubConnectionBuilder().WithUrl("http://localhost:3002/Progress").Build();
            await connection.StartAsync();

            return connection;
        }

        public async Task UpdateGameAsync(bool[][] currentState)
        {
            await using var connection = await OpenConnectionAsync();
            await connection.InvokeAsync(nameof(GameProgressHub.UpdateGameAsync), currentState);
        }

        public async Task RunGameAsync(GameState intialState)
        {
            await using var connection = await OpenConnectionAsync();
            await connection.InvokeAsync(nameof(GameProgressHub.RunGameAsync), intialState);
        }
    }
}
