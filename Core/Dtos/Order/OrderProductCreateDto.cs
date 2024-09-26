using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Order
{
    public class OrderProductCreateDto
    {
        public Guid ProductId { get; set; }
       // public Guid CompanyId { get; set; }

        public int Quantity { get; set; }
        
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }

    }
}
