using ActiveGamesAPI.Models;
using Xunit;

namespace ActiveGamesAPI.Tests
{
    public class GameState_Test
    {
        [Fact]
        public void GameState_VerifyGeneration()
        {
            //Arrange
            var generation = new bool[2][];
            generation[0] = new bool[2] { true, false };
            generation[1] = new bool[2] { false, false };
            var gameState = new GameState();

            //Act
            gameState.Generation = generation;

            //Assert
            Assert.Equal(gameState.Generation, generation);
        }

        [Fact]
        public void GameState_VerifyReactConnectionId()
        {
            //Arrange
            var reactId = "r34342d";
            var gameState = new GameState();

            //Act
            gameState.ReactConnectionId = "r34342d";

            //Assert
            Assert.Equal(gameState.ReactConnectionId, reactId);
        }

        [Fact]
        public void GameState_VerifyRunnerConnectionId()
        {
            //Arrange
            var runnerId = "r4342ed";
            var gameState = new GameState();

            //Act
            gameState.RunnerConnectionId = "r4342ed";

            //Assert
            Assert.Equal(gameState.RunnerConnectionId, runnerId);
        }
    }
}
