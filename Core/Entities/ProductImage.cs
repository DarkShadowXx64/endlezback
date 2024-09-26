using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid UserCreatedId { get; set; }

        // Relaciones
        public Product Product { get; set; }
    }
}
