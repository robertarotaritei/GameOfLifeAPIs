using System.Collections.Generic;
using System.Threading.Tasks;
using GameHistoryAPI.Models;

namespace GameHistoryAPI.Infrastructure
{
    public interface IHistoryQuery
    {
        Task<Game> InsertAsync(Game game);

        Task<Game> UpdateAsync(int id, Game game);

        Task<Game> DeleteAsync(Game game);

        Task<Game> FindOneAsync(int id);

        Task<List<Game>> AllAsync();
    }
}
