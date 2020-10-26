using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using GameHistoryAPI.Infrastructure;
using System.Text.Json;

namespace GameHistoryAPI.Models
{
    public class HistoryQuery : IHistoryQuery
    {
        public AppDb Db { get; }

        public SqlStatement statement { get; }

        public HistoryQuery(string connectionString)
        {
            Db = new AppDb(connectionString);
            statement = new SqlStatement();
        }

        public async Task<Game> InsertAsync(Game body)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = statement.InsertAsync;
            BindParams(cmd, body.Author, body.InitialState);
            await cmd.ExecuteNonQueryAsync();
            body.Id = (int)cmd.LastInsertedId;

            return body;
        }

        public async Task<Game> UpdateAsync(int id, Game game)
        {
            var body = await FindOneAsync(id);
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = statement.UpdateAsync;
            BindParams(cmd, game.InitialState);
            BindId(cmd, body.Id);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<Game> DeleteAsync(int id)
        {
            var body = await FindOneAsync(id);
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = statement.DeleteAsync;
            BindId(cmd, body.Id);
            await cmd.ExecuteNonQueryAsync();

            return body;
        }

        public async Task<Game> FindOneAsync(int id)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = statement.FindOneAsync;
            BindId(cmd, id);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        private async Task<List<Game>> ReadAllAsync(DbDataReader reader)
        {
            var games = new List<Game>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var game = new Game()
                    {
                        Id = reader.GetInt32(0),
                        Author = reader.GetString(1),
                        InitialState = reader.GetString(2),
                    };
                    games.Add(game);
                }
            }
            return games;
        }

        private void BindId(MySqlCommand cmd, int id)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
        }

        private void BindParams(MySqlCommand cmd, string author, string initialState)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@author",
                DbType = DbType.String,
                Value = author,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@initialState",
                DbType = DbType.String,
                Value = initialState,
            });
        }

        private void BindParams(MySqlCommand cmd, string initialState)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@initialState",
                DbType = DbType.String,
                Value = initialState,
            });
        }
    }
}