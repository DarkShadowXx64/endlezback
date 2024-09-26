using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProfilePermission
    {
        public int ProfileId { get; set; }
        public int PermissionId { get; set; }
        public int MenuId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserCreatedId { get; set; }

        // Relación con el perfil (Profile)
        public Profile Profile { get; set; }

        // Relación con el permiso (Permission)
        public Permission Permission { get; set; }

        // Relación con el menú (Menu)
        // public Menu Menu { get; set; }
    }
}
