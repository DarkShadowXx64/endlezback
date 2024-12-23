using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public decimal Total { get; set; }

        public int OrderTypeId { get; set; }
        public OrderType OrderType { get; set; } = null!;

        public Guid OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; } = null!;

        public DateTime CreatedDate { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();


        // Future enhancement for shipments
        // public Guid ShipmentId { get; set; } 
    }
}
