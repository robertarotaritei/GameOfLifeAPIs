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

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateGame(bool[][] currentState)
        {
            var result = await _gameProgressBroadcaster.UpdateGameAsync(currentState);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> RunGame(GameState initialState)
        {
            var result = await _gameProgressBroadcaster.RunGameAsync(initialState);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(initialState);
        }
    }
}
