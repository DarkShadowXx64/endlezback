using Core.Entities;
using System;

namespace Core.Specification
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification() : base(c => true)
        {
            AddInclude(p => p.OrderStatus!);
        }

        public OrderSpecification(Guid? OrderId = null) : base(c => (!OrderId.HasValue || c.Id == OrderId))
        {
            AddInclude(p => p.OrderStatus!);
        }

        public OrderSpecification(Guid OrderId) : base(c => (c.Id == OrderId))
        {
            AddInclude(p => p.OrderStatus!);
        }
    }
}
