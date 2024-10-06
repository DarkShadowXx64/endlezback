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
        public User User { get; set; }
    }
}
