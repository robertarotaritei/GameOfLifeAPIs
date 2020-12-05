using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UserAPI.Infrastructure;
using UserAPI.Models;

namespace UserAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetToken(User user)
        {
            if (user.Username == "admin" && user.Password == "admin")
            {
                var tokenGenerator = new TokenGenerator(user.Username);
                return new ObjectResult(JsonConvert.SerializeObject(tokenGenerator.Token));
            }
            return BadRequest(user.Username);
        }
    }
}
