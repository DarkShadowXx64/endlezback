using Core.Entities;
using System;

namespace Core.Specification
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification()
        {
            AddInclude(p => p.Category!);
            AddInclude(p => p.UserCreated!);
            AddInclude(p => p.UserChanged!);
        }

        public ProductSpecification(Guid? ProductId = null) : base(c => !c.IsDeleted && (!ProductId.HasValue || c.Id == ProductId))
        {
            AddInclude(p => p.Category!);
            AddInclude(p => p.UserCreated!);
            AddInclude(p => p.UserChanged!);
        }

        public ProductSpecification(Guid ProductId) : base(c => !c.IsDeleted && (c.Id == ProductId))
        {
            AddInclude(p => p.Category!);
            AddInclude(p => p.UserCreated!);
            AddInclude(p => p.UserChanged!);
        }
    }
}
