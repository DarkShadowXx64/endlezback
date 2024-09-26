using Core.Dtos.User;

namespace Business.Logic.AuthLogic
{
    public class AuthResponse : BaseResponse<UserDto>
    {
        public string? Token { get; set; }
    }
}
