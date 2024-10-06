using Core.Entities;
using Core.Dtos.OrderStatus;
using Core.Dtos.OrderType;
using Core.Dtos.User;

namespace Core.Dtos.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public UserDto User { get; set; }
        public OrderTypeDto OrderType { get; set; }
        public OrderStatusDto OrderStatus { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = [];
    }
}
