using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Enable { get; set; }
        public bool IsDeleted { get; set; }
        public string Sku { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
        //public Guid CompanyId { get; set; }
        public Guid UserCreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserChangedId { get; set; }
        public DateTime ChangedDate { get; set; }
        public Guid UserDeletedId { get; set; }
        public DateTime? DeletedDate { get; set; }

        // Relaciones
        public string Category { get; set; } = string.Empty;
      //  public string Company { get; set; } = string.Empty;
        public string UserCreated { get; set; } = string.Empty;
        public string UserChanged { get; set; } = string.Empty;
    }
}
