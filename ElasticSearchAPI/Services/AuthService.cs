using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ElasticSearchAPI
{
    /// <inheritdoc/> 
    public class AuthService(IConfiguration Config) : IAuthService
    {
        /// <inheritdoc/> 
        public bool ValidateCretentials(string username, string password)
        {
            return username == "admin" && password == "pass";
        }

        /// <inheritdoc/> 
        public string GenerateJwtToken(string username)
        {
            var settings = Config.GetSection("Jwt");
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    [
                        new Claim(ClaimTypes.Name, username),
                    ]),
                Expires = DateTime.UtcNow.AddDays(1),
                Issuer = settings["Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings["Key"])), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}
