using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;
using Newtonsoft.Json;
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

        public async Task<User> InsertAsync(User user)
        {
            if (user.Username.Length > 3 && user.Password.Length > 4)
            {
                await Db.Connection.OpenAsync();
                using var cmd = Db.Connection.CreateCommand();
                cmd.CommandText = Statement.InsertAsync;
                BindParams(cmd, user.Username, user.Password);
                await cmd.ExecuteNonQueryAsync();

                user.Id = (int)cmd.LastInsertedId;
                return user;
            }

            return null;
        }

        public async Task<User> UpdateAsync(UserNewPassword user)
        {
            var body = await VerifyOneAsync(user.Username, user.Password);
            var result = new User();

            if (body != null && TokenGenerator.VerifyJWTToken(body.Token, user.Token))
            {
                using var cmd = Db.Connection.CreateCommand();
                cmd.CommandText = Statement.UpdateAsync;
                BindParams(cmd, user.Username, user.NewPassword);
                await cmd.ExecuteNonQueryAsync();
                result.Username = user.Username;
                result.Password = user.NewPassword;
            }

            return result.Username != "" ? result : null;
        }

        public async Task<User> DeleteAsync(User user)
        {
            var body = await VerifyOneAsync(user.Username, user.Password);

            if (body != null && TokenGenerator.VerifyJWTToken(body.Token, user.Token))
            {
                using var cmd = Db.Connection.CreateCommand();
                cmd.CommandText = Statement.DeleteAsync;
                BindParams(cmd, user.Username, user.Password);
                await cmd.ExecuteNonQueryAsync();
            }

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

        public async Task<User> FindTokenAsync(string username, string token)
        {
            await Db.Connection.OpenAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = Statement.FindTokenAsync;
            BindUsername(cmd, username);
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());

            var user = result.Count > 0 ? result[0] : null;
            if(user == null)
                return null;

            if (!TokenGenerator.VerifyJWTToken(user.Token, token))
                return null;

            return user;
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

        public async Task<string> UpdateTokenAsync(string username, string password)
        {
            var body = await VerifyOneAsync(username, password);
            string result = "";
            
            if (body != null)
            {
                var tokenGenerator = new TokenGenerator(username);
                var token = JsonConvert.SerializeObject(tokenGenerator.Token);

                using var cmd = Db.Connection.CreateCommand();
                cmd.CommandText = Statement.UpdateTokenAsync;
                BindUsername(cmd, username);
                BindToken(cmd, token);
                await cmd.ExecuteNonQueryAsync();
                result = token;
            }

            return result;
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
                        Token = reader.GetString(3)
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
    }
}