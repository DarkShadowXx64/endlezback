using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.CustomerAddress
{
    public class CustomerAddressCreateDto
    {
        
        public Guid UserId { get; set; }
        public string Street { get; set; }
        public string StreetDetail { get; set; }
        public string Number { get; set; }
        public string Zip { get; set; }
        public string Reference { get; set; }
        public bool IsPrincipal { get; set; }

        
    }
}
