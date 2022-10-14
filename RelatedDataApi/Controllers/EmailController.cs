using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Models;
using RelatedDataApi.Services;
using RelatedDataApi.Services.EmailService;

namespace RelatedDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailServices _email;
        public EmailController(IEmailServices email)
        {
            _email = email;
        }

        [HttpPost("EmailController")]

        public ActionResult<ServiceResponse<string>> sendEmailControlller(string body)
        {
            try
            {
                //Creating the email message
                var email = new MimeMessage();
                //Email Props
                email.From.Add(MailboxAddress.Parse("eldon.sauer@ethereal.email"));
                email.To.Add(MailboxAddress.Parse("eldon.sauer@ethereal.email"));
                email.Subject = "Test Email from the controller";
                email.Body = new TextPart(TextFormat.Html) { Text = body };
                //In this part you choose the format of text

                //Smtp Part
                using var smtp = new SmtpClient();
                smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                //In this part you are putting the host and the port and the socket options
                smtp.Authenticate("eldon.sauer@ethereal.email", "M6BtzjBQGbgaKRZKWA");
                smtp.Send(email);
                smtp.Disconnect(true);
                return Ok(new ServiceResponse<string>() { Message = "The email was send" });

            } catch (Exception e)
            {
                return Ok(new ServiceResponse<string>() { Message = e.Message, Success = false });
            }
        }

        [HttpPost("EmailService")]

        public ActionResult<ServiceResponse<string>> sendEmailService(Email request)
        {
            return Ok(_email.sendEmailService(request));
        }
    }
}
