using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Product
{
    public class ProductCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public string Codigo { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
      //  public Guid CompanyId { get; set; }
        public Guid UserCreatedId { get; set; }

    }
}
