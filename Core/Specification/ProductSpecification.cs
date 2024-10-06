using Core.Entities;
using System;

namespace Core.Specification
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification()
        {
            AddInclude(p => p.Category!);
        }

        public ProductSpecification(Guid? ProductId = null) : base(c =>(!ProductId.HasValue || c.Id == ProductId))
        {
            AddInclude(p => p.Category!);
        }

        public ProductSpecification(Guid ProductId) : base(c => (c.Id == ProductId))
        {
            AddInclude(p => p.Category!);
        }
    }
}
