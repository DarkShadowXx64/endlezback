using Core.Entities;

namespace Core.Interface;

public interface IJwtGenerator
{
    string GenerateToken(User user);
}