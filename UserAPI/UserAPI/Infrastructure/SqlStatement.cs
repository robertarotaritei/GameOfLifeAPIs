using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Infrastructure
{
    public class SqlStatement
    {
        public string InsertAsync { get; set; }

        public string UpdateAsync { get; set; }

        public string DeleteAsync { get; set; }

        public string FindOneAsync { get; set; }

        public string VerifyOneAsync { get; set; }

        public string VerifyUsernameAsync { get; set; }

        public SqlStatement()
        {
            InsertAsync = @"INSERT INTO `user` (`user_name`, `password`) VALUES (@username, @password);";
            UpdateAsync = @"UPDATE `user` SET `password` = @password WHERE `id` = @id;";
            DeleteAsync = @"DELETE FROM `user` WHERE `id` = @id;";
            FindOneAsync = @"SELECT * FROM `user` WHERE `id` = @id";
            VerifyOneAsync = @"SELECT * FROM `user` WHERE `user_name` = @username AND `password` = @password";
            VerifyUsernameAsync = @"SELECT * FROM `user` WHERE `user_name` = @username;";
        }
    }
}
