using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MailSender
    {
        private string _user;
        private string _password;
        private string _serverSmtp;
        private int _portSmtp;

        public MailSender( string user, string password, string serverSmtp, int portSmtp)
        {
            _user = user;
            _password = password;
            _serverSmtp = serverSmtp;
            _portSmtp = portSmtp;
            
        }

        public void SendMail(string to, string subject, string body)
        {
            try
            {
                using (SmtpClient clienteSmtp = new SmtpClient(_serverSmtp, _portSmtp))
                {
                    clienteSmtp.EnableSsl = true;
                    clienteSmtp.UseDefaultCredentials = false;
                    clienteSmtp.Credentials = new NetworkCredential(_user, _password);

                    MailMessage mensaje = new MailMessage(_user, to, subject, body);
                    mensaje.IsBodyHtml = true;

                    clienteSmtp.Send(mensaje);
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción apropiadamente (registro, notificación, etc.)
                Console.WriteLine("Error al enviar correo electrónico: " + ex.Message);
            }
        }
    }
}
