using Models;

namespace RelatedDataApi.Services.EmailService
{
    public interface IEmailServices
    {
        ServiceResponse<string> sendEmailService(Email request);
    }
}
