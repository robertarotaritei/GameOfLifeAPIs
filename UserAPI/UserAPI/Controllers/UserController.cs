using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        public AppDb Db { get; }

        public UserController(AppDb db)
        {
            Db = db;
        }

        // GET user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // GET user/verify?username=bob&password=1234
        [HttpGet]
        [Route("verify")]
        public async Task<IActionResult> VerifyOne(string username, string password)
        {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            var result = await query.VerifyOneAsync(username, password);
            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // GET user/verifyusername?username=bob
        [HttpGet]
        [Route("verifyusername")]
        public async Task<IActionResult> VerifyUsername(string username)
        {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            var result = await query.VerifyUsernameAsync(username);
            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }


        // POST user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }

        // PUT user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] string password)
        {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            result.Password = password;
            await result.UpdateAsync();
            return new OkObjectResult(result);
        }

        // DELETE user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new UserQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }
    }
}