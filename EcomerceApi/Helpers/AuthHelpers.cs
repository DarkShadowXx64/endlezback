using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Dtos.User;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Core.Interface;

namespace EcomerceApi.Helpers

{
    public class AuthHelpers: IAuthHelpers
    {
        private readonly IConfiguration _configuration;

        public AuthHelpers(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string  GenerateJWTtoken(UserDto user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
            };

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                         Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"])
                    ),
                    SecurityAlgorithms.HmacSha256Signature
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}