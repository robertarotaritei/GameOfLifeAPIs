using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameHistoryAPI.Models;

namespace GameHistoryAPI.Infrastructure
{
    public interface IHistoryQuery
    {
        Task<Game> InsertAsync(Game body);

        Task<Game> UpdateAsync(int id, Game body);

        Task<Game> DeleteAsync(int id);

        Task<Game> FindOneAsync(int id);
    }
}
