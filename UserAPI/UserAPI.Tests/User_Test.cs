using System;
using System.Collections.Generic;
using System.Text;
using UserAPI.Models;
using Xunit;

namespace UserAPI.Tests
{
    public class User_Test
    {
        [Fact]
        public void VerifyUser()
        {
            //Arrange
            User user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
                Id = 2
            };

            //Assert
            Assert.IsType<User>(user);
            Assert.Equal("Michael", user.Username);
            Assert.Equal("qwerty", user.Password);
        }

        [Fact]
        public void VerifyUsernameEqual()
        {
            //Arrange
            User user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
                Id = 2
            };

            //Act
            var result = user;
            user.Username = "Daniel";

            //Assert
            Assert.IsType<User>(result);
            Assert.Equal(user.Username, result.Username);
        }

        [Fact]
        public void VerifyUsernameNotEqual()
        {
            //Arrange
            User user = new User()
            {
                Username = "Michael",
                Password = "qwerty",
                Id = 2
            };

            //Act
            var result = new User();
            result = user;
            user.Username = "Daniel";

            //Assert
            Assert.IsType<User>(result);
            Assert.Equal(user.Username, result.Username);
        }
    }
}
