using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Infrastructure;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("credentials/[controller]")]
    public class UserController
    {
        public IUserQuery _userQuery { get; }

        public UserController(IUserQuery userQuery)
        { 
            _userQuery = userQuery;
        }

        // GET credentials/user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var result = await _userQuery.FindOneAsync(id);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // GET credentials/user/verify?username=bob&password=1234
        [HttpGet]
        [Route("verify")]
        public async Task<IActionResult> VerifyOne(string username, string password)
        {
            var result = await _userQuery.VerifyOneAsync(username, password);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // GET credentials/user/verifyusername?username=bob
        [HttpGet]
        [Route("verifyusername")]
        public async Task<IActionResult> VerifyUsername(string username)
        {
            var result = await _userQuery.VerifyUsernameAsync(username);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // POST credentials/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User body)
        {
            if (body.Username.Length > 3 && body.Password.Length > 4)
            {
                await _userQuery.InsertAsync(body);

                return new OkObjectResult(body);
            }

            return new NotFoundResult();
        }

        // PUT credentials/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] string password)
        {
            var result = await _userQuery.UpdateAsync(id, password);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // DELETE credentials/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            var result = await _userQuery.DeleteAsync(id);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }
    }
}