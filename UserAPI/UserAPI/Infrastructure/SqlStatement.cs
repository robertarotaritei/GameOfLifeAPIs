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
            InsertAsync = @"INSERT INTO `user` (`user_name`, `password`) VALUES (@username, AES_ENCRYPT(@password,'secret'));";
            UpdateAsync = @"UPDATE `user` SET `password` = AES_ENCRYPT(@password,'secret') WHERE `id` = @id;";
            UpdateTokenAsync = @"UPDATE `user` SET `token` = @token WHERE `user_name` = @username AND `password` = AES_ENCRYPT(@password,'secret');";
            DeleteAsync = @"DELETE FROM `user` WHERE `id` = @id AND `password` = @password;";
            FindOneAsync = @"SELECT * FROM `user` WHERE `id` = @id";
            FindTokenAsync = @"SELECT `token` FROM `user` WHERE `user_name` = @username";
            VerifyOneAsync = @"SELECT * FROM `user` WHERE `user_name` = @username AND `password` = AES_ENCRYPT(@password,'secret');";
            VerifyUsernameAsync = @"SELECT * FROM `user` WHERE `user_name` = @username;";
        }
    }
}
