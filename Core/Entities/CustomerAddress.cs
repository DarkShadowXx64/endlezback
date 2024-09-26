using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Street { get; set; }
        public string StreetDetail { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string Reference { get; set; }
        public bool IsPrincipal { get; set; }
        public bool Enabled { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
