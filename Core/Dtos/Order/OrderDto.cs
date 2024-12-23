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
        public UserDto User { get; set; } = null!;
        public OrderTypeDto OrderType { get; set; } = null!;
        public OrderStatusDto OrderStatus { get; set; } = null!;

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
