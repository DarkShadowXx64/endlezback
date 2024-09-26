using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Business.Logic.AuthLogic;
using Core.Dtos.User;
using Core.Interface;
using EcomerceApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace EcomerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly AuthResponse _response;
        private readonly IMapper _mapper;
        private readonly IAuthHelpers _authHelpers;

        public AuthController(IAuthRepository authRepository, AuthResponse response, IMapper mapper, IAuthHelpers authHelpers)
        {
            _authRepository = authRepository;
            _response = response;
            _mapper = mapper;
            _authHelpers = authHelpers;
        }

        [HttpPost]
        public async Task<AuthResponse> SignIn(AuthRequest request)
        {
            try
            {
                var result = await _authRepository.GetByUsernameAndPassword(request.Email, request.Password);
                if (result is null)
                {
                    _response.Message = "No existe el usuario con los datos proporcionados";
                    _response.statusCode = 404;
                    return _response;
                }
                _response.DataObject = _mapper.Map<UserDto>(result);
                string jwtToken = _authHelpers.GenerateJWTtoken(_mapper.Map<UserDto>(result));
                _response.Token = jwtToken;
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
                throw;
            }
            
            return _response;
        }

        
        //[HttpGet]
        //public async Task<AuthResponse> RecoveryPassword(string email)
        //{
        //    _response.Message = "Blaa..";

        //    return _response;
        //}
    }
}
