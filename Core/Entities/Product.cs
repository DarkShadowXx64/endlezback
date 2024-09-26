using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Enable { get; set; }
        public bool IsDeleted { get; set; }
        public string Sku { get; set; }
        public string Codigo { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Guid CategoryId { get; set; }
       // public Guid CompanyId { get; set; }
        public Guid UserCreatedId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserChangedId { get; set; }
        public DateTime ChangedDate { get; set; }
        public Guid UserDeletedId { get; set; }
        public DateTime? DeletedDate { get; set; }

        // Relaciones
        public Category Category { get; set; }
       // public Company Company { get; set; }
        public User UserCreated { get; set; }
        public User UserChanged { get; set; }


    }
}
