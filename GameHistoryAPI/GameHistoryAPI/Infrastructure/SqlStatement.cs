using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameHistoryAPI.Infrastructure
{
    public class SqlStatement
    {
        public string InsertAsync { get; set; }

        public string UpdateAsync { get; set; }

        public string DeleteAsync { get; set; }

        public string FindOneAsync { get; set; }

        public SqlStatement()
        {
            InsertAsync = @"INSERT INTO `game_history` (`author`, `initial_state`) VALUES (@author, @initialState);";
            UpdateAsync = @"UPDATE `game_history` SET `initial_state` = @initialState WHERE `game_id` = @id;";
            DeleteAsync = @"DELETE FROM `game_history` WHERE `game_id` = @id;";
            FindOneAsync = @"SELECT * FROM `game_history` WHERE `game_id` = @id";
        }
    }
}
