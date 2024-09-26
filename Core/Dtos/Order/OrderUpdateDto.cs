using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Order
{
    public class OrderUpdateDto
    {
        public Guid Id { get; set; }
        //public Guid CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int OrderTypeId { get; set; }
        public Guid OrderStatusId { get; set; }
       // public Guid CompanyId { get; set; }
        public List<OrderProduct> OrderProducts { get; set; }

    }
}
