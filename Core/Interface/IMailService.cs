using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IMailService
    {
        public void SendMail(string to, string subject, string body);

    }

}
