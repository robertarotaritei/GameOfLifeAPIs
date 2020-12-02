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
        public async Task UpdateGame_VerifyObject()
        {
            //Arrange
            var generation = new bool[2][];
            generation[0] = new bool[2] { true, false };
            generation[1] = new bool[2] { false, false };
            var gameState = new GameState()
            {
                Generation = generation,
                ReactConnectionId = "",
                RunnerConnectionId = ""
            };

            var activeGamesMock = new Mock<IGameProgressBroadcaster>();
            activeGamesMock.Setup(x => x.UpdateGameAsync(gameState)).ReturnsAsync(gameState);
            var service = new ActiveGamesController(activeGamesMock.Object);

            //Act
            var result = await service.UpdateGame(gameState) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(gameState, actualResult);
        }

        [Fact]
        public async Task UpdateGame_VerifyInvalidObject()
        {
            //Arrange
            GameState gameState = null;

            var activeGamesMock = new Mock<IGameProgressBroadcaster>();
            activeGamesMock.Setup(x => x.UpdateGameAsync(gameState)).ReturnsAsync(gameState);
            var service = new ActiveGamesController(activeGamesMock.Object);

            //Act
            var result = await service.UpdateGame(gameState) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task RunGame_VerifyObject()
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
            activeGamesMock.Setup(x => x.UpdateGameAsync(gameState)).ReturnsAsync(gameState);
            var service = new ActiveGamesController(activeGamesMock.Object);

            //Act
            var result = await service.RunGame(gameState) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(gameState, ((GameState)actualResult));
        }

        [Fact]
        public async Task RunGame_VerifyInvalidObject()
        {
            //Arrange
            GameState gameState = null;

            var activeGamesMock = new Mock<IGameProgressBroadcaster>();
            activeGamesMock.Setup(x => x.RunGameAsync(gameState)).ReturnsAsync(gameState);
            var service = new ActiveGamesController(activeGamesMock.Object);

            //Act
            var result = await service.RunGame(gameState) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
