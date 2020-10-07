using ActiveGamesAPI.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveGamesAPI.Hubs
{
    public class GameProgressHub: Hub
    {
        public async Task UpdateGameAsync(int gameId, GameState currentState)
        {
            await Clients.All.SendAsync("GameProgressed", gameId, currentState);
        }
        public async Task RunGameAsync(int gameId, GameState intialState)
        {
            await Clients.All.SendAsync("GameInitiated", gameId, intialState);
        }
    }
}
