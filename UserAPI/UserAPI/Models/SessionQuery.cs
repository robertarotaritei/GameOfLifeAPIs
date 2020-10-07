using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySqlConnector;

namespace UserAPI.Models
{
    public class SessionQuery
    {
        public AppDb Db { get; }

        public SessionQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Session> FindOneAsync(int userId)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `session` WHERE `user_id` = @userId";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@userId",
                DbType = DbType.Int32,
                Value = userId,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Session>> FindAllAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `session`";
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result;
        }

        private async Task<List<Session>> ReadAllAsync(DbDataReader reader)
        {
            var sessions = new List<Session>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var session = new Session(Db)
                    {
                        Id = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        Time = reader.GetDateTime(2).ToString(),
                    };
                    sessions.Add(session);
                }
            }
            return sessions;
        }
    }
}
