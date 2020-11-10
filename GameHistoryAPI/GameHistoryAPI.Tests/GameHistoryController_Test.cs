using Xunit;
using GameHistoryAPI.Models;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNetCore.Mvc;
using GameHistoryAPI.Infrastructure;
using GameHistoryAPI.Controllers;
using System.Collections.Generic;

namespace GameHistoryAPI.Tests
{
    public class GameHistoryController_Test
    {
        [Fact]
        public async Task InsertAsync_VerifyObject()
        {
            //Arrange
            var game = new Game()
            {
                Author = "Michael",
                InitialState = "[[true,false],[false,false]]"
            };

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.InsertAsync(game)).ReturnsAsync(game);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.Post(game) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(game, (Game)actualResult);
        }

        [Fact]
        public async Task InsertAsync_VerifyInvalidAuthor()
        {
            //Arrange
            Game returnedGame = null;
            var game = new Game()
            {
                Author = "",
                InitialState = "[[true,false],[false,false]]"
            };

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.InsertAsync(game)).ReturnsAsync(returnedGame);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.Post(game) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task InsertAsync_VerifyInvalidGameState()
        {
            //Arrange
            Game returnedGame = null;
            var game = new Game()
            {
                Author = "Michael",
                InitialState = ""
            };

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.InsertAsync(game)).ReturnsAsync(returnedGame);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.Post(game) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task AllAsync_VerifyObject()
        {
            //Arrange
            var games = new List<Game>();
            var game = new Game()
            {
                Author = "Michael",
                InitialState = "[[true,false],[false,false]]"
            };
            games.Add(game);
            game = new Game()
            {
                Author = "Dan",
                InitialState = "[[true,true],[false,false]]"
            };
            games.Add(game);

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.AllAsync()).ReturnsAsync(games);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.GetAll() as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(games, (List<Game>)actualResult);
        }

        [Fact]
        public async Task AllAsync_VerifyInvalidData()
        {
            //Arrange
            var games = new List<Game>();

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.AllAsync()).ReturnsAsync(games);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.GetAll() as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateAsync_VerifyGameState()
        {
            //Arrange
            string newState = "[[true,false],[false,false]]";
            var game = new Game()
            {
                Id = 2,
                InitialState = "[[false,false],[true,true]]"
            };

            var returnedGame = new Game()
            {
                Id = game.Id,
                InitialState = newState
            };

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.UpdateAsync(game.Id, game)).ReturnsAsync(returnedGame);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.PutOne(game.Id, game) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(returnedGame, (Game)actualResult);
        }

        [Fact]
        public async Task UpdateAsync_VerifyInvalidGameState()
        {
            //Arrange
            Game returnedGame = null;
            string newState = "";
            var game = new Game()
            {
                Id = 2,
                InitialState = "[[false,false],[true,true]]"
            };
            game.InitialState = newState;

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.UpdateAsync(game.Id, game)).ReturnsAsync(returnedGame);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.PutOne(game.Id, game) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_VerifyGameState()
        {
            //Arrange
            var game = new Game()
            {
                Id = 2,
                Author = "Michael",
                InitialState = "[[true,false],[false,false]]"
            };

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.DeleteAsync(game.Id)).ReturnsAsync(game);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.DeleteOne(game.Id) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(game, (Game)actualResult);
        }

        [Fact]
        public async Task DeleteAsync_VerifyInvalidId()
        {
            //Arrange
            var id = 0;
            Game returnedGame = null;

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.DeleteAsync(id)).ReturnsAsync(returnedGame);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.DeleteOne(id) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task FindOneAsync_VerifyObject()
        {
            //Arrange
            var game = new Game()
            {
                Id = 2,
                Author = "Michael",
                InitialState = "[[true,false],[false,false]]"
            };

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.FindOneAsync(game.Id)).ReturnsAsync(game);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.GetOne(game.Id) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(game, (Game)actualResult);
        }

        [Fact]
        public async Task FindOneAsync_VerifyInvalidId()
        {
            //Arrange
            var id = 0;
            Game returnedUser = null;

            var userMock = new Mock<IHistoryQuery>();
            userMock.Setup(x => x.FindOneAsync(id)).ReturnsAsync(returnedUser);
            var service = new GameHistoryController(userMock.Object);

            //Act
            var result = await service.GetOne(id) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
