using Xunit;
using UserAPI.Models;
using System.Threading.Tasks;
using Moq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using UserAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using UserAPI.Infrastructure;

namespace UserAPI.Tests
{
    public class UserController_Test
    {
        [Fact]
        public async Task GetOne_CreatesUserAsync()
        {
            //Arrange
            User user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
                Id = 2
            };

            var userMock = new Mock<IUserQuery>();

            userMock.Setup(x => x.FindOneAsync(user.Id)).ReturnsAsync(user);

            //Act
            var service = new UserController(userMock.Object);
            var result = await service.GetOne(user.Id) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user.Username, ((User)actualResult).Username);
        }

        [Fact]
        public async Task PutOne_UpdatesUserAsync()
        {
            //Arrange
            User user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
                Id = 2
            };
            string newPassword = "password";
            user.Password = newPassword;

            var userMock = new Mock<IUserQuery>();
            
            userMock.Setup(x => x.UpdateAsync(user.Id, newPassword)).ReturnsAsync(user);

            //Act
            var service = new UserController(userMock.Object);
            var result = await service.PutOne(user.Id, newPassword) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user.Username, ((User)actualResult).Username);
            Assert.Equal(newPassword, ((User)actualResult).Password);
        }

        [Fact]
        public async Task DeleteOne_DeletesUserAsync()
        {
            //Arrange
            User user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
                Id = 2
            };

            var userMock = new Mock<IUserQuery>();

            userMock.Setup(x => x.DeleteAsync(user.Id)).ReturnsAsync(user);

            //Act
            var service = new UserController(userMock.Object);
            var result = await service.DeleteOne(user.Id) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user.Username, ((User)actualResult).Username);
            Assert.Equal(user.Password, ((User)actualResult).Password);
        }

        [Fact]
        public async Task GetOne_FindsUserAsync()
        {
            //Arrange
            User user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
                Id = 2
            };

            var userMock = new Mock<IUserQuery>();

            userMock.Setup(x => x.FindOneAsync(user.Id)).ReturnsAsync(user);

            //Act
            var service = new UserController(userMock.Object);
            var result = await service.GetOne(user.Id) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user.Username, ((User)actualResult).Username);
            Assert.Equal(user.Password, ((User)actualResult).Password);
        }

        [Fact]
        public async Task VerifyOne_VerifyUserAsync()
        {
            //Arrange
            User user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
                Id = 2
            };

            var userMock = new Mock<IUserQuery>();

            userMock.Setup(x => x.VerifyOneAsync(user.Username, user.Password)).ReturnsAsync(user);

            //Act
            var service = new UserController(userMock.Object);
            var result = await service.VerifyOne(user.Username, user.Password) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user.Username, ((User)actualResult).Username);
            Assert.Equal(user.Password, ((User)actualResult).Password);
        }

        [Fact]
        public async Task VerifyUsername_VerifyUsernameAsync()
        {
            //Arrange
            User user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
                Id = 2
            };

            var userMock = new Mock<IUserQuery>();

            userMock.Setup(x => x.VerifyUsernameAsync(user.Username)).ReturnsAsync(user);

            //Act
            var service = new UserController(userMock.Object);
            var result = await service.VerifyUsername(user.Username) as OkObjectResult;
            var actualResult = result.Value;

            //Assert
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(user.Username, ((User)actualResult).Username);
            Assert.Equal(user.Password, ((User)actualResult).Password);
        }
        
    }
}
