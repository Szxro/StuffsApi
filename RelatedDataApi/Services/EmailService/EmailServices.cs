using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using Models;

namespace RelatedDataApi.Services.EmailService
{
    public class EmailServices : IEmailServices 
    {
        private readonly IConfiguration _configuration;
        public EmailServices(IConfiguration configuration)
        {
           _configuration = configuration;
        }

        public ServiceResponse<string> sendEmailService(Email request)
        {
            //Some Validations
            if (request.Subject.Length <= 0)
                return new ServiceResponse<string>() { Message = "The Subject need to be fill", Success = false };
            if (request.Body.Length <= 0)
                return new ServiceResponse<string>() { Message = "The Body need to be fill", Success = false };
            if (request.To.Length <= 0)
                return new ServiceResponse<string>() { Message = "The To part need to be fill", Success = false };

            try
            {
                //Email Part
                var email = new MimeMessage();
                //Email Props
                email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailUsername").Value));
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };
                //In this part you choose the format of text

                //Smtp Part
                using var smtp = new SmtpClient();
                smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                //In this part you are putting the host and the port and the socket options
                smtp.Authenticate(_configuration.GetSection("EmailUsername").Value,_configuration.GetSection("EmailPassword").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
                return new ServiceResponse<string>() { Message = "The email was send" };

            } 
            catch (Exception e)
            {
                return new ServiceResponse<string>() { Message = e.Message, Success = false };
            }
        }
    }
}
