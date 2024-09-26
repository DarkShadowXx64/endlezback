using AutoMapper;
using Business.Logic.OrderLogic;
using Core.Dtos.Order;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly OrderResponse _response;
        private IMapper _mapper;

        public OrderController(IGenericRepository<Order> orderRepository
            , OrderResponse response
             , IMapper mapper
            )
        {
            _orderRepository = orderRepository;
            _response = response;
            _mapper = mapper;

        }



        [HttpGet]
        public async Task<ActionResult<OrderResponse>> GetAll(Guid CompanyId, Guid? CustomerId)
        {
            try
            {
                var spec = new OrderSpecification();
                var user = await _orderRepository.GetAllAsync();
                _response.ListDataObject = _mapper.Map<IReadOnlyList<OrderDto>>(user);
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return Ok(_response);
        }

      




        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Post(OrderCreateDto user)
        {
            try
            {
                var _user = _mapper.Map<Order>(user);
                var result = await _orderRepository.Insert(_user);
                _response.DataObject = _mapper.Map<OrderDto>(_user);
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }

            return Ok(_response);
        }

        [HttpPut]
        public async Task<OrderResponse> Update(OrderUpdateDto user)
        {
            try
            {
                var existingUser = await _orderRepository.GetByGuidAsync(user.Id);
                if (existingUser == null)
                {
                    _response.statusCode = 404;
                    _response.Message = "El usuario no se encontró.";
                    return _response;
                }
                var originalCreatedDate = existingUser.CreatedDate;

                var _user = _mapper.Map(user, existingUser);

                _orderRepository.Update(_user);
                var result = await _orderRepository.SaveAsync();
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
        public async Task<OrderResponse> SoftDeleteUser(Guid id)
        {
            try
            {
                await _orderRepository.SoftDeleteByGuid(id);
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
