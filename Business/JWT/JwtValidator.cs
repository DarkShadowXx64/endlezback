using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Core.Entities;
using Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Business.JWT;

public class JwtValidator : IJwtValidator
{
    private readonly IConfiguration _configuration;
    
    public JwtValidator(IConfiguration configuration, IGenericRepository<User> userRepository)
    {
        _configuration = configuration;
    }
    
    public Guid ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Authentication:Key").Value!);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = jwtToken.Claims.First(x => x.Type == "id").Value;

            if (Guid.TryParse(userId, out var userGuid))
                return userGuid;
            else
                throw new Exception("Token invalido");
            
        }
        catch (SecurityTokenException)
        {
            throw new Exception("Token invalido");
        }
        catch (Exception)
        {
            throw new Exception("Token validation failed");
        }     
    }
}