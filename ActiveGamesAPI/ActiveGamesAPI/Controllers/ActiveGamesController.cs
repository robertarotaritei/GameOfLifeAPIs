using ActiveGamesAPI.Infrastructure;
using ActiveGamesAPI.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> UpdateGame(GameInfo gameInfo)
        {
            var result = await _gameProgressBroadcaster.SendGameInfo(gameInfo);

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
