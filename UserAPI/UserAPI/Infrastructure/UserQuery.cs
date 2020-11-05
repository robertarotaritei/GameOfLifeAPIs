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
            if (body.Username.Length > 3 && body.Password.Length > 4)
            {
                await Db.Connection.OpenAsync();
                using var cmd = Db.Connection.CreateCommand();
                cmd.CommandText = Statement.InsertAsync;
                BindParams(cmd, body.Username, body.Password);
                await cmd.ExecuteNonQueryAsync();

                body.Id = (int)cmd.LastInsertedId;
                return body;
            }

            return null;
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

        public async Task<User> DeleteAsync(int id)
        {
            var body = await FindOneAsync(id);
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.DeleteAsync;
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

        public async Task<User> VerifyOneAsync(string username, string password)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.VerifyOneAsync;
            BindParams(cmd, username, password);
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