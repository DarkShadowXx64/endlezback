using AutoMapper;
using Business.Logic.OrderLogic;
using Business.Logic.OrderStatusLogic;
using Business.Logic.OrderTypeLogic;
using Core.Dtos.OrderStatus;
using Core.Dtos.OrderType;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTypeController : ControllerBase
    {
        private readonly IGenericRepository<OrderType> _orderTypeRepository;
        private readonly OrderTypeResponse _response;
        private IMapper _mapper;

        public OrderTypeController(IGenericRepository<OrderType> orderTypeRepository
             , OrderTypeResponse response
             , IMapper mapper
            )
        {
            _orderTypeRepository = orderTypeRepository;
            _response = response;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<OrderTypeResponse>> GetAll()
        {
            try
            {
                var user = await _orderTypeRepository.GetAllAsync();
                _response.ListDataObject = _mapper.Map<IReadOnlyList<OrderTypeDto>>(user);
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return Ok(_response);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<OrderTypeResponse>> GetById(int id)
        {
            try
            {
                var user = await _orderTypeRepository.GetByIdAsync(id);
                _response.DataObject = _mapper.Map<OrderTypeDto>(user);

            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);

            }
            return Ok(_response);
        }




        [HttpPost]
        public async Task<ActionResult<OrderTypeResponse>> Post(OrderTypeCreateDto user)
        {
            try
            {
                var _user = _mapper.Map<OrderType>(user);
                var result = await _orderTypeRepository.Insert(_user);
                _response.DataObject = _mapper.Map<OrderTypeDto>(_user);
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }

            return Ok(_response);
        }

        [HttpPut]
        public async Task<OrderTypeResponse> Update(OrderStatusUpdateDto user)
        {
            try
            {
                var existingUser = await _orderTypeRepository.GetByGuidAsync(user.Id);
                if (existingUser == null)
                {
                    _response.statusCode = 404;
                    _response.Message = "El usuario no se encontró.";
                    return _response;
                }

                var _user = _mapper.Map(user, existingUser);

                _orderTypeRepository.Update(_user);
                var result = await _orderTypeRepository.SaveAsync();
                _response.Message = "El cambio de usuario se realizó con éxito.";
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }

            return _response;
        }


        [HttpDelete("{id}")]
        public async Task<OrderTypeResponse> SoftDeleteUser(int id)
        {
            try
            {
                await _orderTypeRepository.Delete(id);
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
