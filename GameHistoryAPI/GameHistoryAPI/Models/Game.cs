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

        internal AppDb Db { get; set; }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `game_history` (`author`, `initial_state`) VALUES (@author, @initialState);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@author",
                DbType = DbType.String,
                Value = Author,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@initialState",
                DbType = DbType.String,
                Value = InitialState,
            });
        }
        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = Id,
            });
        }
    }
}
