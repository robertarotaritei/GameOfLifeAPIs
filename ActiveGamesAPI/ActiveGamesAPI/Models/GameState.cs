using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActiveGamesAPI.Models
{
    public class GameState
    {
        public bool[][] Generation { get; set; }
        public string ReactConnectionId { get; set; }
        public string RunnerConnectionId { get; set; }

        public GameState()
        {

        }
    }
}
