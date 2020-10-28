using Xunit;
using UserAPI.Models;
using System.Threading.Tasks;
using Moq;
using UserAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Infrastructure;

namespace UserAPI.Tests
{
    public class UserController_Test
    {
        [Fact]
        public async Task InsertAsync_VerifyObject()
        {
            //Arrange
            var user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.InsertAsync(user)).ReturnsAsync(user);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.Post(user) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(user, ((User)actualResult));
        }

        [Fact]
        public async Task InsertAsync_VerifyInvalidUsername()
        {
            //Arrange
            User returnedUser = null;
            var user = new User()
            {
                Username = "",
                Password = "qwerty",
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.InsertAsync(user)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.Post(user) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task InsertAsync_VerifyInvalidPassword()
        {
            //Arrange
            User returnedUser = null;
            var user = new User()
            {
                Username = "Michael",
                Password = "",
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.InsertAsync(user)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.Post(user) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateAsync_VerifyPassword()
        {
            //Arrange
            string newPassword = "qwerty";
            int id = 2;

            var returnedUser = new User()
            {
                Id = 2,
                Password = "qwerty"
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.UpdateAsync(id, newPassword)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.PutOne(id, newPassword) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(newPassword, ((User)actualResult).Password);
        }

        [Fact]
        public async Task UpdateAsync_VerifyInvalidPassword()
        {
            //Arrange
            string newPassword = "";
            int id = 2;
            User returnedUser = null;

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.UpdateAsync(id, newPassword)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.PutOne(id, newPassword) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateAsync_VerifyInvalidId()
        {
            //Arrange
            string newPassword = "password";
            int id = 0;
            User returnedUser = null;

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.UpdateAsync(id, newPassword)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.PutOne(id, newPassword) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_VerifyObject()
        {
            //Arrange
            var user = new User()
            {
                Id = 2,
                Username = "Michael",
                Password = "qwerty"
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.DeleteAsync(user.Id)).ReturnsAsync(user);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.DeleteOne(user.Id) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(user, ((User)actualResult));
        }

        [Fact]
        public async Task DeleteAsync_VerifyInvalidId()
        {
            //Arrange
            User returnedUser = null;
            int id = 0;

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.DeleteAsync(id)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.DeleteOne(id) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task FindOneAsync_VerifyObject()
        {
            //Arrange
            var user = new User()
            {
                Id = 2,
                Username = "Michael",
                Password = "qwerty"
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.FindOneAsync(user.Id)).ReturnsAsync(user);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.GetOne(user.Id) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(user, ((User)actualResult));
        }

        [Fact]
        public async Task FindOneAsync_VerifyInvalidId()
        {
            //Arrange
            User returnedUser = null;
            int id = 0;

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.FindOneAsync(id)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.GetOne(id) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task VerifyOneAsync_VerifyObject()
        {
            //Arrange
            var user = new User()
            {
                Id = 2,
                Username = "Michael",
                Password = "qwerty"
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.VerifyOneAsync(user.Username, user.Password)).ReturnsAsync(user);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.VerifyOne(user.Username, user.Password) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(user, ((User)actualResult));
        }

        [Fact]
        public async Task VerifyOneAsync_VerifyInvalidData()
        {
            //Arrange
            User returnedUser = null;
            string username = "Michael";
            string password = "qwerty";

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.VerifyOneAsync(username, password)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.VerifyOne(username, password) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task VerifyUsernameAsync_VerifyObject()
        {
            //Arrange
            var user = new User()
            {
                Id = 2,
                Username = "Michael",
                Password = "qwerty"
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.VerifyUsernameAsync(user.Username)).ReturnsAsync(user);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.VerifyUsername(user.Username) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(user, ((User)actualResult));
        }

        [Fact]
        public async Task VerifyUsernameAsync_VerifyInvalidData()
        {
            //Arrange
            User returnedUser = null;
            string username = "";

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.VerifyUsernameAsync(username)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.VerifyUsername(username) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
