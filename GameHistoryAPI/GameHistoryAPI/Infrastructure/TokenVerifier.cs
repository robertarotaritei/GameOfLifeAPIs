using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GameHistoryAPI.Infrastructure
{
    public class TokenVerifier
    {
        public static bool VerifyJWTToken(string token, string author)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadToken(token) as JwtSecurityToken;

            if (!VerifyJWTClaim(tokenS, author) || tokenS.ValidTo < DateTime.UtcNow)
                return true;

            return false;
        }

        private static bool VerifyJWTClaim(JwtSecurityToken tokenS, string author)
        {
            var claims = tokenS.Claims;

            foreach (Claim claim in claims)
            {
                if (claim.Value == author)
                    return true;
            }

            return false;
        }
    }
}
