using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.Infrastructure
{
    public class SqlStatement
    {
        public string InsertAsync { get; }

        public string UpdateAsync { get; }

        public string DeleteAsync { get; }

        public string FindOneAsync { get; }

        public string VerifyOneAsync { get;  }

        public string VerifyUsernameAsync { get; }

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
