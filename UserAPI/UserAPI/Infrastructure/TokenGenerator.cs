using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserAPI.Infrastructure
{
    public class TokenGenerator
    {
        private const string SECRET_KEY = "mysuperlongandsecuresecretkey";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public object Token { get; set; }

        public TokenGenerator(string username)
        {
            Token = GenerateToken(username);
        }

        private object GenerateToken(string username)
        {
            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, "Admin"),

                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddHours(8)).DateTime,
                signingCredentials: new SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256)

                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static bool VerifyJWTToken(string foundToken, string givenToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(foundToken);

            if (foundToken != givenToken || givenToken == "" || jsonToken.ValidTo < DateTime.UtcNow)
                return false;

            return true;
        }
    }
}
