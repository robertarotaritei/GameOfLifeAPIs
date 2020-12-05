using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
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
            var result = await _userQuery.UpdateTokenAsync(username, password);

            if (result is "")
                return new NotFoundResult();

            return new ObjectResult(result);
        }

        // GET credentials/user/verifyusername?username=bob
        [HttpGet]
        [Route("verifyusername")]
        public async Task<IActionResult> VerifyUsername(string username)
        {
            var result = await _userQuery.VerifyUsernameAsync(username);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result.Username);
        }

        // GET credentials/user/token?username=bob&token=sfefwfver23r
        [HttpGet]
        [Route("token")]
        public async Task<bool> GetToken(string username, string token)
        {
            var result = await _userQuery.FindTokenAsync(username, token);

            if(result is null)
                return false;

            return true;
        }

        // POST credentials/user
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var result = await _userQuery.InsertAsync(user);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(user);
        }

        // PUT credentials/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne([FromBody] UserNewPassword user)
        {            
            var result = await _userQuery.UpdateAsync(user);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // DELETE credentials/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne([FromBody] User user)
        {
            var result = await _userQuery.DeleteAsync(user);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }
    }
}