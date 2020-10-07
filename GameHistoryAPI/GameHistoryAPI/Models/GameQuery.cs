using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameHistoryAPI.Models
{
    public class GameQuery
    {
        public AppDb Db { get; }

        public GameQuery(AppDb db)
        {
            Db = db;
        }

    }
}
