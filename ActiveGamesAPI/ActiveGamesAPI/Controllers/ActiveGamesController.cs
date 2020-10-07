using ActiveGamesAPI.Infrastructure;
using ActiveGamesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveGamesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActiveGamesController
    {
        private readonly IGameProgressBroadcaster _gameProgressBroadcaster;

        public ActiveGamesController(IGameProgressBroadcaster gameProgressBroadcaster)
        {
            _gameProgressBroadcaster = gameProgressBroadcaster;
        }

        [HttpPost("{id}")]
        public async Task UpdateGame(int id, GameState currentState)
        {
            await _gameProgressBroadcaster.UpdateGameAsync(id, currentState);
        }

        [HttpPost]
        public async Task RunGame(int id, GameState initialState)
        {
            await _gameProgressBroadcaster.RunGameAsync(id, initialState);
        }
    }
}
