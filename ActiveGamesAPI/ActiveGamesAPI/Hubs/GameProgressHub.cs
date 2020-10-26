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
        public async Task UpdateGameAsync(bool[][] currentState)
        {
            await Clients.All.SendAsync("GameProgressed", currentState);
        }
        public async Task RunGameAsync(GameState intialState)
        {
            await Clients.All.SendAsync("GameInitiated", intialState);
        }
    }
}
