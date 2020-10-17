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
            var id = 2;
            var generation = new bool[2, 2] { { true, false }, { false, false } };
            var gameState = new GameState()
            {
                IsFinal = false,
                Generation = generation,
            };

            var activeGamesMock = new Mock<IGameProgressBroadcaster>();

            activeGamesMock.Setup(x => x.UpdateGameAsync(id, gameState));

            //Act
            var service = new ActiveGamesController(activeGamesMock.Object);
            var result = await service.UpdateGame(id, gameState) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(gameState.IsFinal, ((GameState)actualResult).IsFinal);
            Assert.Equal(gameState.Generation, ((GameState)actualResult).Generation);
        }

        [Fact]
        public async Task RunGame_RunsGameState()
        {
            //Arrange
            var id = 2;
            var generation = new bool[2, 2] { { true, false }, { false, false } };
            var gameState = new GameState()
            {
                IsFinal = false,
                Generation = generation,
            };

            var activeGamesMock = new Mock<IGameProgressBroadcaster>();

            activeGamesMock.Setup(x => x.RunGameAsync(id, gameState));

            //Act
            var service = new ActiveGamesController(activeGamesMock.Object);
            var result = await service.RunGame(id, gameState) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(gameState.IsFinal, ((GameState)actualResult).IsFinal);
            Assert.Equal(gameState.Generation, ((GameState)actualResult).Generation);
        }
    }
}
