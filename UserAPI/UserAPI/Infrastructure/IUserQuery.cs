using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Infrastructure
{
    public interface IUserQuery
    {
        Task<User> InsertAsync(User body);

        Task<User> UpdateAsync(int id, string password);

        Task<User> DeleteAsync(int id);

        Task<User> FindOneAsync(int id);

        Task<User> VerifyOneAsync(string username, string password);

        Task<User> VerifyUsernameAsync(string username);
    }
}
