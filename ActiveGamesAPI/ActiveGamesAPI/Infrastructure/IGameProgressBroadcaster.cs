﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ActiveGamesAPI.Models;

namespace ActiveGamesAPI.Infrastructure
{
    public interface IGameProgressBroadcaster
    {
        Task UpdateGameAsync(int gameId, GameState currentState);

        Task RunGameAsync(int gameId, GameState intialState);
    }
}
