using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace UserAPI.Models
{
    public class Session
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Time { get; set; }

        internal AppDb Db { get; set; }

        internal Session(AppDb db)
        {
            Db = db;
        }

        public Session()
        {

        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `session` (`user_id`, `time`) VALUES (@userId, @time);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            Id = (int)cmd.LastInsertedId;
        }

        public async Task UpdateAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"UPDATE `session` SET `time` = @time WHERE `user_id` = @userId;";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `session` WHERE `user_id` = @userId;";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
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

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@userId",
                DbType = DbType.Int32,
                Value = UserId,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@time",
                DbType = DbType.DateTime,
                Value = DateTime.Parse(Time),
            });
        }
    }
}
