using UserAPI.Infrastructure;
using Xunit;

namespace UserAPI.Tests
{
    public class SqlStatement_Test
    {
        [Fact]
        public void SqlStatment_InserAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"INSERT INTO `user` (`user_name`, `password`) VALUES (@username, AES_ENCRYPT(@password,'secret'));";

            //Act
            var result = sqlStatement.InsertAsync;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqlStatment_UpdateAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"UPDATE `user` SET `password` = AES_ENCRYPT(@password,'secret') WHERE `id` = @id;";

            //Act
            var result = sqlStatement.UpdateAsync;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqlStatment_UpdateTokenAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"UPDATE `user` SET `token` = @token WHERE `user_name` = @username AND `password` = AES_ENCRYPT(@password,'secret');";

            //Act
            var result = sqlStatement.UpdateTokenAsync;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqlStatment_DeleteAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"DELETE FROM `user` WHERE `id` = @id AND `password` = @password;";

            //Act
            var result = sqlStatement.DeleteAsync;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqlStatment_FindOneAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"SELECT * FROM `user` WHERE `id` = @id";

            //Act
            var result = sqlStatement.FindOneAsync;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqlStatment_FindTokenAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"SELECT `token` FROM `user` WHERE `user_name` = @username";

            //Act
            var result = sqlStatement.FindTokenAsync;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqlStatment_VerifyOneAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"SELECT * FROM `user` WHERE `user_name` = @username AND `password` = AES_ENCRYPT(@password,'secret');";

            //Act
            var result = sqlStatement.VerifyOneAsync;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqlStatment_VerifyUsernameAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"SELECT * FROM `user` WHERE `user_name` = @username;";

            //Act
            var result = sqlStatement.VerifyUsernameAsync;

            //Assert
            Assert.Equal(expected, result);
        }
    }
}