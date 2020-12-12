using GameHistoryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GameHistoryAPI.Infrastructure;

namespace GameHistoryAPI.Controllers
{
    [ApiController]
    [Route("history/[controller]")]
    public class GameHistoryController
    {
        public IHistoryQuery _historyQuery { get; }

        public GameHistoryController(IHistoryQuery historyQuery)
        {
            _historyQuery = historyQuery;
        }

        // GET history/gamehistory
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _historyQuery.AllAsync();

            if (result.Count == 0)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // GET history/gamehistory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _historyQuery.FindOneAsync(id);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // POST "history/gamehistory
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Game body)
        {
            var result = await _historyQuery.InsertAsync(body);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(body);
        }

        // PUT "history/gamehistory/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Game body)
        {
            var result = await _historyQuery.UpdateAsync(id, body);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // DELETE "history/gamehistory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne([FromBody] Game body)
        {
            var result = await _historyQuery.DeleteAsync(body);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }
    }
}
