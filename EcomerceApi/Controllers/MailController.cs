using Core.Dtos.MailDto;
using Core.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendMail([FromBody] MailDto mailDto)
        {
            _mailService.SendMail(mailDto.To, mailDto.Subject, mailDto.Body);
            return Ok("blaaa...");
        }
    }
}
