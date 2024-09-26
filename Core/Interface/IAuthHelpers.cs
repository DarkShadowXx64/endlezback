using Core.Dtos.User;

namespace Core.Interface
{
    public interface IAuthHelpers
    {
        string GenerateJWTtoken(UserDto user);
    }
}