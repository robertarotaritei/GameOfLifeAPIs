using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveGamesAPI.Models
{
    public class Game
    {
        public int Id { get; set; }

        public GameState[] States { get; set; }

        public GameState CurrentState { get; set; }
    }
}
