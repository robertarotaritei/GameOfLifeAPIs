using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Infrastructure
{
    public interface IUserQuery
    {
        Task<User> InsertAsync(User user);

        Task<User> UpdateAsync(UserNewPassword user);

        Task<string> UpdateTokenAsync(string username, string password);

        Task<User> DeleteAsync(User user);

        Task<User> FindOneAsync(int id);

        Task<User> FindTokenAsync(string username, string token);

        Task<User> VerifyOneAsync(string username, string password);

        Task<User> VerifyUsernameAsync(string username);
    }
}
