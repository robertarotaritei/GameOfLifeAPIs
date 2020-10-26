using ActiveGamesAPI.Controllers;
using ActiveGamesAPI.Infrastructure;
using ActiveGamesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace ActiveGamesAPI.Tests
{
    public class ActiveGamesController_Test
    {
        [Fact]
        public async Task UpdateGame_UpdatesGameState()
        {
            //Arrange
            var generation = new bool[2][];
            generation[0] = new bool[2] { true, false };
            generation[1] = new bool[2] { false, false };
            var gameState = new GameState()
            {
                Generation = generation,
            };

            var activeGamesMock = new Mock<IGameProgressBroadcaster>();

            activeGamesMock.Setup(x => x.UpdateGameAsync(gameState.Generation));

            //Act
            var service = new ActiveGamesController(activeGamesMock.Object);
            var result = await service.UpdateGame(gameState.Generation) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(gameState.Generation, actualResult);
        }

        [Fact]
        public async Task RunGame_RunsGameState()
        {
            //Arrange
            var generation = new bool[2][];
            generation[0] = new bool[2] { true, false };
            generation[1] = new bool[2] { false, false };
            var gameState = new GameState()
            {
                Generation = generation,
            };

            var activeGamesMock = new Mock<IGameProgressBroadcaster>();

            activeGamesMock.Setup(x => x.RunGameAsync(gameState));

            //Act
            var service = new ActiveGamesController(activeGamesMock.Object);
            var result = await service.RunGame(gameState) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(gameState, ((GameState)actualResult));
        }
    }
}
