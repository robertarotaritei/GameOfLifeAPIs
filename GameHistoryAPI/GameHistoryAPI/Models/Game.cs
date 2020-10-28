using System;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;
using Newtonsoft.Json;

namespace GameHistoryAPI.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string InitialState { get; set; }

        public Game()
        {

        }
    }
}
