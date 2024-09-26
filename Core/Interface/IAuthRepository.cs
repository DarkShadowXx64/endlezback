using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IAuthRepository
    {
        Task<User?> GetByUsernameAndPassword(string Email, string Password);

        Task<User> RecoveryPassword(string Email);

        Task<User> ChangePassword(string Email, string Password);

    }
}
