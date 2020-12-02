using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Infrastructure
{
    public interface IUserQuery
    {
        Task<User> InsertAsync(User body);

        Task<User> UpdateAsync(int id, string password);

        Task<User> UpdateTokenAsync(string username, string password, string token);

        Task<User> DeleteAsync(int id, string password);

        Task<User> FindOneAsync(int id);

        Task<string> FindTokenAsync(string username);

        Task<User> VerifyOneAsync(string username, string password);

        Task<User> VerifyUsernameAsync(string username);
    }
}
