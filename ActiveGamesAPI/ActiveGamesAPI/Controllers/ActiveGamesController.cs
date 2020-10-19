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
    [Route("games/[controller]")]
    public class ActiveGamesController
    {
        private readonly IGameProgressBroadcaster _gameProgressBroadcaster;

        public ActiveGamesController(IGameProgressBroadcaster gameProgressBroadcaster)
        {
            _gameProgressBroadcaster = gameProgressBroadcaster;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateGame(int id, GameState currentState)
        {
            await _gameProgressBroadcaster.UpdateGameAsync(id, currentState);

            return new OkObjectResult(currentState);
        }

        [HttpPost]
        public async Task<IActionResult> RunGame(int id, GameState initialState)
        {
            await _gameProgressBroadcaster.RunGameAsync(id, initialState);

            return new OkObjectResult(initialState);
        }
    }
}
