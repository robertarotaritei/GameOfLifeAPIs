using Xunit;
using UserAPI.Models;
using System.Threading.Tasks;
using Moq;
using UserAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Infrastructure;
using Newtonsoft.Json;

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
            var newUserPassword = new UserNewPassword()
            {
                Id = 2,
                Password = "qwerty",
                NewPassword = "qwerty2"
            };

            var newUser = new User()
            {
                Id = 2,
                Password = "qwerty2"
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.UpdateAsync(newUserPassword)).ReturnsAsync(newUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.PutOne(newUserPassword) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(newUserPassword.NewPassword, ((User)actualResult).Password);
        }

        [Fact]
        public async Task UpdateAsync_VerifyInvalidPassword()
        {
            //Arrange
            var userNewPassword = new UserNewPassword()
            {
                Id = 2,
                Password = "",
                NewPassword = ""
            };

            User returnedUser = null;

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.UpdateAsync(userNewPassword)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.PutOne(userNewPassword) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateAsync_VerifyInvalidId()
        {
            //Arrange
            var userNewPassword = new UserNewPassword()
            {
                Id = 2,
                Password = "password",
                NewPassword = "password"
            };

            User returnedUser = null;

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.UpdateAsync(userNewPassword)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.PutOne(userNewPassword) as NotFoundResult;

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteAsync_VerifyObject()
        {
            //Arrange
            var tokenGenerator = new TokenGenerator("Michael");
            var token = JsonConvert.SerializeObject(tokenGenerator.Token);
            var user = new User()
            {
                Id = 2,
                Username = "Michael",
                Password = "qwerty",
                Token = token
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.DeleteAsync(user)).ReturnsAsync(user);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.DeleteOne(user) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.Equal(user, ((User)actualResult));
        }

        [Fact]
        public async Task DeleteAsync_VerifyInvalidId()
        {
            //Arrange
            User returnedUser = null;
            var user = new User()
            {
                Id = 0,
                Username = "Michael",
                Password = "qwerty"
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.DeleteAsync(user)).ReturnsAsync(returnedUser);
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.DeleteOne(user) as NotFoundResult;

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
        public async Task VerifyOneAsync_VerifyInvalidData()
        {
            //Arrange
            var user = new User()
            {
                Username = "Michael",
                Password = "qwerty"
            };

            var userMock = new Mock<IUserQuery>();
            userMock.Setup(x => x.UpdateTokenAsync(user.Username, user.Password)).ReturnsAsync("");
            var service = new UserController(userMock.Object);

            //Act
            var result = await service.VerifyOne(user.Username, user.Password) as NotFoundResult;

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
            Assert.Equal(user.Username, actualResult);
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
