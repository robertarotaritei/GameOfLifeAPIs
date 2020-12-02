using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using UserAPI.Infrastructure;

namespace UserAPI.Models
{
    public class UserQuery : IUserQuery
    {
        public AppDb Db { get; }

        public SqlStatement Statement { get; }

        public UserQuery(string connectionString)
        {
            Db = new AppDb(connectionString);
            Statement = new SqlStatement();
        }

        public async Task<User> InsertAsync(User body)
        {
                await Db.Connection.OpenAsync();
                using var cmd = Db.Connection.CreateCommand();
                cmd.CommandText = Statement.InsertAsync;
                BindParams(cmd, body.Username, body.Password);
                await cmd.ExecuteNonQueryAsync();

                body.Id = (int)cmd.LastInsertedId;
                return body;
        }

        public async Task<User> UpdateAsync(int id, string password)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.UpdateAsync;
            BindPassword(cmd, password);
            BindId(cmd, id);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());

            return result.Count > 0 ? result[0] : null;
        }

        public async Task<User> DeleteAsync(int id, string password)
        {
            var body = await FindOneAsync(id);
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.DeleteAsync;
            BindPassword(cmd, password);
            BindId(cmd, id);
            await cmd.ExecuteNonQueryAsync();

            return body;
        }

        public async Task<User> FindOneAsync(int id)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.FindOneAsync;
            BindId(cmd, id);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());

            return result.Count > 0 ? result[0] : null;
        }

        public async Task<string> FindTokenAsync(string username)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.FindTokenAsync;
            BindUsername(cmd, username);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());

            return result.Count > 0 ? result[0].Token : "";
        }

        public async Task<User> VerifyOneAsync(string username, string password)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.VerifyOneAsync;
            BindParams(cmd, username, password);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());

            return result.Count > 0 ? result[0] : null;
        }

        public async Task<User> UpdateTokenAsync(string username, string password, string token)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.UpdateTokenAsync;
            BindParams(cmd, username, password);
            BindToken(cmd, token);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());

            return result.Count > 0 ? result[0] : null;
        }

        public async Task<User> VerifyUsernameAsync(string username)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.VerifyUsernameAsync;
            BindUsername(cmd, username);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());

            return result.Count > 0 ? result[0] : null;
        }

        private async Task<List<User>> ReadAllAsync(DbDataReader reader)
        {
            var users = new List<User>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var user = new User()
                    {
                        Id = reader.GetInt32(0),
                        Username = reader.GetString(1),
                        Password = reader.GetString(2),
                    };
                    users.Add(user);
                }
            }

            return users;
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

        private void BindParams(MySqlCommand cmd, string username, string password)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@username",
                DbType = DbType.String,
                Value = username,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@password",
                DbType = DbType.String,
                Value = password,
            });
        }

        private void BindUsername(MySqlCommand cmd, string username)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@username",
                DbType = DbType.String,
                Value = username,
            });
        }

        private void BindToken(MySqlCommand cmd, string token)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@token",
                DbType = DbType.String,
                Value = token,
            });
        }

        private void BindPassword(MySqlCommand cmd, string password)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@password",
                DbType = DbType.String,
                Value = password,
            });
        }
    }
}