using AutoMapper;
using Business.Logic.OrderLogic;
using Business.Logic.OrderStatusLogic;
using Core.Dtos.Order;
using Core.Dtos.OrderStatus;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IGenericRepository<OrderStatus> _orderStatusRepository;
        private readonly OrderStatusResponse _response;
        private IMapper _mapper;

        public OrderStatusController(IGenericRepository<OrderStatus> orderStatusRepository
             , OrderStatusResponse response
             , IMapper mapper
            )
        {
            _orderStatusRepository = orderStatusRepository;
            _response = response;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<OrderStatusResponse>> GetAll()
        {
            try
            {
                var user = await _orderStatusRepository.GetAllAsync();
                _response.ListDataObject = _mapper.Map<IReadOnlyList<OrderStatusDto>>(user);
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return Ok(_response);
        }




        [HttpGet("{id}")]
        public async Task<ActionResult<OrderStatusResponse>> GetById(int id)
        {
            try
            {
                var user = await _orderStatusRepository.GetByIdAsync(id);
                _response.DataObject = _mapper.Map<OrderStatusDto>(user);

            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);

            }
            return Ok(_response);
        }




        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Post(OrderStatusCreateDto user)
        {
            try
            {
                var _user = _mapper.Map<OrderStatus>(user);
                var result = await _orderStatusRepository.Insert(_user);
                _response.DataObject = _mapper.Map<OrderStatusDto>(_user);
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }

            return Ok(_response);
        }

        [HttpPut]
        public async Task<OrderStatusResponse> Update(OrderStatusUpdateDto user)
        {
            try
            {
                var existingUser = await _orderStatusRepository.GetByGuidAsync(user.Id);
                if (existingUser == null)
                {
                    _response.statusCode = 404;
                    _response.Message = "El usuario no se encontró.";
                    return _response;
                }

                var _user = _mapper.Map(user, existingUser);

                _orderStatusRepository.Update(_user);
                var result = await _orderStatusRepository.SaveAsync();
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
        public async Task<OrderStatusResponse> SoftDeleteUser(Guid id)
        {
            try
            {
                await _orderStatusRepository.Delete(id);
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
