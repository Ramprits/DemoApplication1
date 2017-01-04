using System.Threading.Tasks;

namespace DemoApplication1.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
