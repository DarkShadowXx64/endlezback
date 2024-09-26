using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        //public Guid CustomerId { get; set; }
      //  public string Customer { get; set; }

        public decimal Total { get; set; }

        public int OrderTypeId { get; set; }
        public virtual string OrderType { get; set; }
        public Guid OrderStatusId { get; set; }
        public  string OrderStatus { get; set; }
      //  public Guid CompanyId { get; set; }
      //  public string Company { get; set; }
        public bool Enabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public DateTime DeletedDate { get; set; }


        public List<OrderProduct> OrderProducts { get; set; }

    }
}
