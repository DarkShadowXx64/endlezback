using AutoMapper;
using Business.Logic.UserLogic;
using Core.Dtos.User;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace EcomerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly UserResponse _response;
        private IMapper _mapper;

        public UserController(IGenericRepository<User> userRepository
            , UserResponse response
             , IMapper mapper
            )
        {
            _userRepository = userRepository;
            _response = response;
            _mapper = mapper;

        }



        [HttpGet]
        public async Task<ActionResult<UserResponse>> GetAll()
        {
            try
            {
                var spec = new UserSpecification();
                var user = await _userRepository.GetAllWhitSpec(spec);
                //var data= user.Where(u=>u.CompanyId == CompanyId && u.IsDeleted==false);
                _response.ListDataObject = _mapper.Map<List<UserDto>>(user);
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return Ok(_response);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetUserById(Guid id)
        {
            try
            {
                var spec = new UserSpecification();
                var user = await _userRepository.GetAllWhitSpec(spec);
                var _user = user.Where(u => u.Id == id).FirstOrDefault();
                _response.DataObject = _mapper.Map<UserDto>(_user);

            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);

            }
            return Ok(_response);
        }



        [HttpPost]
        public async Task<ActionResult<UserResponse>> Post(UserCreateDto user)
        {
            try
            {
                var _user = _mapper.Map<User>(user);
                var result = await _userRepository.Insert(_user);
                _response.DataObject = _mapper.Map<UserDto>(_user);
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }

            return Ok(_response);
        }

        [HttpPut]
        public async Task<UserResponse> Update(UserUpdateDto user)
        {
            try
            {
                var existingUser = await _userRepository.GetByGuidAsync(user.Id);
                if (existingUser == null)
                {
                    _response.statusCode = 404;
                    _response.Message = "El usuario no se encontró.";
                    return _response;
                }
                //var originalCreatedDate = existingUser.CreatedDate;


                var _user = _mapper.Map(user, existingUser);
               // _user.CreatedDate = originalCreatedDate;


                _userRepository.Update(_user);
                var result = await _userRepository.SaveAsync();
                _response.Message = "El cambio de usuario se realizó con éxito.";
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }

            return _response;
        }


        [HttpDelete("softdelete/{id}")]
        public async Task<UserResponse> SoftDeleteUser(Guid id)
        {
            try
            {
                await _userRepository.SoftDeleteByGuid(id);
                _response.Message = "Se eliminó el usuario";
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);

            }
            return _response;

        }
    }
}
