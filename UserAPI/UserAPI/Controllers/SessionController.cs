using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController
    {
        public AppDb Db { get; }

        public SessionController(AppDb db)
        {
            Db = db;
        }

        // GET session/5
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetOne(int userId)
        {
            await Db.Connection.OpenAsync();
            var query = new SessionQuery(Db);
            var result = await query.FindOneAsync(userId);
            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // POST session
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Session body)
        {
            await Db.Connection.OpenAsync();
            var query = new SessionQuery(Db);
            var result = await query.FindOneAsync(body.UserId);
            if (result is null)
            {
                body.Db = Db;
                await body.InsertAsync();
                return new OkObjectResult(body);
            }
            else
            {
                result.Time = DateTime.Now.ToString();
                await result.UpdateAsync();
                return new OkObjectResult(result);
            }
        }

        // PUT session/5
        [HttpPut("{userId}")]
        public async Task<IActionResult> PutOne(int userId)
        {
            await Db.Connection.OpenAsync();
            var query = new SessionQuery(Db);
            var result = await query.FindOneAsync(userId);
            if (result is null)
                return new NotFoundResult();
            result.Time = DateTime.Now.ToString();
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE session/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteOne(int userId)
        {
            await Db.Connection.OpenAsync();
            var query = new SessionQuery(Db);
            var result = await query.FindOneAsync(userId);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE session
        [HttpDelete]
        public async Task<IActionResult> DeleteOld()
        {
            await Db.Connection.OpenAsync();
            var query = new SessionQuery(Db);
            var result = await query.FindAllAsync();
            if (result is null)
                return new NotFoundResult();
            foreach(var row in result)
            {
                if ((DateTime.Now - DateTime.Parse(row.Time)).TotalMinutes > 15)
                {
                    await row.DeleteAsync();
                }
            }
            return new OkResult();
        }
    }
}
