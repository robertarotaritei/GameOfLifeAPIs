namespace UserAPI.Infrastructure
{
    public class SqlStatement
    {
        public string InsertAsync { get; }

        public string UpdateAsync { get; }

        public string UpdateTokenAsync { get; }

        public string DeleteAsync { get; }

        public string FindOneAsync { get; }

        public string FindTokenAsync { get; }

        public string VerifyOneAsync { get;  }

        public string VerifyUsernameAsync { get; }

        public SqlStatement()
        {
            InsertAsync = @"INSERT INTO `user` (`user_name`, `password`) VALUES (@username, MD5(@password);";
            UpdateAsync = @"UPDATE `user` SET `password` = MD5(@password) WHERE `user_name` = @username;";
            UpdateTokenAsync = @"UPDATE `user` SET `token` = @token WHERE `user_name` = @username;";
            DeleteAsync = @"DELETE FROM `user` WHERE `user_name` = @username AND `password` = @password;";
            FindOneAsync = @"SELECT * FROM `user` WHERE `id` = @id";
            FindTokenAsync = @"SELECT * FROM `user` WHERE `user_name` = @username";
            VerifyOneAsync = @"SELECT * FROM `user` WHERE `user_name` = @username AND `password` = MD5(@password);";
            VerifyUsernameAsync = @"SELECT * FROM `user` WHERE `user_name` = @username;";
        }
    }
}
