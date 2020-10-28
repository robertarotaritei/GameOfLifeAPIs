using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActiveGamesAPI.Models;

namespace ActiveGamesAPI.Infrastructure
{
    public interface IGameProgressBroadcaster
    {
        Task<bool[][]> UpdateGameAsync(bool[][] currentState);

        Task<GameState> RunGameAsync(GameState intialState);
    }
}
