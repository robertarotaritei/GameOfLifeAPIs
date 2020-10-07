using GameHistoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace GameHistoryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameHistoryController
    {
        public AppDb Db { get; }

        public GameHistoryController(AppDb db)
        {
            Db = db;
        }

        // POST gamehistory
        [HttpPost]
        public async Task<IActionResult> Post(Game body)
        {            
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

    }
}
