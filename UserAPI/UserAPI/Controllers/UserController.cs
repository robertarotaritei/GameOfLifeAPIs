using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using UserAPI.Infrastructure;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [ApiController]
    [Route("credentials/[controller]")]
    public class UserController
    {
        private const string SECRET_KEY = "mysuperlongandsecuresecretkey";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
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
            var result = await _userQuery.VerifyOneAsync(username, password);

            if (result is null)
                return new NotFoundResult();

            var token = JsonConvert.SerializeObject(GenerateToken(username));
            await _userQuery.UpdateTokenAsync(username, password, token.Substring(1, token.Length - 2));
            return new ObjectResult(token);
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
        public async Task<IActionResult> GetToken(string username, string token)
        {
            var result = await _userQuery.FindTokenAsync(username);

            if (result != token || result == "")
                return new NotFoundResult();

            return new OkObjectResult(true);
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
        public async Task<IActionResult> PutOne(int id, [FromBody] User user)
        {
            var result = await _userQuery.UpdateAsync(id, user.Password);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        // DELETE credentials/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id, [FromBody] User user)
        {
            var result = await _userQuery.DeleteAsync(id, user.Password);

            if (result is null)
                return new NotFoundResult();

            return new OkObjectResult(result);
        }

        private object GenerateToken(string username)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)

                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddHours(8)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}