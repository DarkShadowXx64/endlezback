using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool Enabled { get; set; }
        public bool IsDeleted { get; set; }
        public int? ProfileId { get; set; }
        public string ProfileName { get; set; }
     //   public Guid? CompanyId { get; set; }
       // public string CompanyName { get; set; }

    }
}


