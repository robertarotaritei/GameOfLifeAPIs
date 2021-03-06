﻿namespace GameHistoryAPI.Infrastructure
{
    public class SqlStatement
    {
        public string InsertAsync { get; }

        public string UpdateAsync { get; }

        public string DeleteAsync { get; }

        public string FindOneAsync { get; }

        public string AllAsync { get; }

        public SqlStatement()
        {
            InsertAsync = @"INSERT INTO `game_history` (`author`, `initial_state`) VALUES (@author, @initialState);";
            UpdateAsync = @"UPDATE `game_history` SET `initial_state` = @initialState WHERE `game_id` = @id;";
            DeleteAsync = @"DELETE FROM `game_history` WHERE `game_id` = @id;";
            FindOneAsync = @"SELECT * FROM `game_history` WHERE `game_id` = @id";
            AllAsync = @"SELECT * FROM `game_history`";
        }
    }
}
