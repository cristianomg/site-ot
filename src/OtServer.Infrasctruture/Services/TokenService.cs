using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OtServer.Domain.Config;
using OtServer.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OtServer.Infrasctruture.Services
{
    public class TokenService : ITokenService
    {
        private string _jwtSecretKey;
        public TokenService(IOptions<CryptographConfig> config)
        {
            _jwtSecretKey = config.Value.JwtSecretKey;
        }

        public string GenerateToken(string id, string name, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role),
                    new Claim("Account", id),

                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
