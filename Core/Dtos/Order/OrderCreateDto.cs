using Core.Dtos.Product;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Order
{
    public class OrderCreateDto
    {
        
        public Guid CustomerId { get; set; }
        public decimal Total { get; set; }

        public int OrderTypeId { get; set; }

        public Guid OrderStatusId { get; set; }

       // public Guid CompanyId { get; set; }
        
        public List<OrderProductCreateDto> Products { get; set; }

    }
}
