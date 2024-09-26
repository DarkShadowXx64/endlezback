using Core.Entities;
using System;

namespace Core.Specification
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification() : base(c => !c.IsDeleted)
        {
            AddInclude(p => p.OrderStatus!);
        }

        public OrderSpecification(Guid? OrderId = null) : base(c => !c.IsDeleted && (!OrderId.HasValue || c.Id == OrderId))
        {
            AddInclude(p => p.OrderStatus!);
        }

        public OrderSpecification(Guid OrderId) : base(c => !c.IsDeleted && (c.Id == OrderId))
        {
            AddInclude(p => p.OrderStatus!);
        }
    }
}
