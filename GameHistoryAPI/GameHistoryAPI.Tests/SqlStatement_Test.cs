using GameHistoryAPI.Infrastructure;
using Xunit;

namespace GameHistoryAPI.Tests
{
    public class SqlStatement_Test
    {
        [Fact]
        public void SqlStatment_InserAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"INSERT INTO `game_history` (`author`, `initial_state`) VALUES (@author, @initialState);";

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
            var expected = @"UPDATE `game_history` SET `initial_state` = @initialState WHERE `game_id` = @id;";

            //Act
            var result = sqlStatement.UpdateAsync;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqlStatment_DeleteAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"DELETE FROM `game_history` WHERE `game_id` = @id;";

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
            var expected = @"SELECT * FROM `game_history` WHERE `game_id` = @id";

            //Act
            var result = sqlStatement.FindOneAsync;

            //Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void SqlStatment_VerifyOneAsync()
        {
            //Arrange
            var sqlStatement = new SqlStatement();
            var expected = @"SELECT * FROM `game_history`";

            //Act
            var result = sqlStatement.AllAsync;

            //Assert
            Assert.Equal(expected, result);
        }
    }
}