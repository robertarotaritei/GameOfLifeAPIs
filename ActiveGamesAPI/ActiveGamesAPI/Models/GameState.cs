using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveGamesAPI.Models
{
    public class GameState
    {
        public bool IsFinal { get; set; }

        public bool[][] Generation { get; set; }

        public GameState()
        {

        }
    }
}
