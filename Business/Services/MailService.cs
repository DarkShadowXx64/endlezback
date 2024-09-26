using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MailService : IMailService
    {
        private readonly MailSender _sender;


        public MailService(MailSender sender)
        {
            _sender = sender;
        }

        public void SendMail(string to, string subject, string body)
        {
            _sender.SendMail(to, subject, body);
        }

       
    }
}
