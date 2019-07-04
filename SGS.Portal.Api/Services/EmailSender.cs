using System.Threading.Tasks;

namespace SGS.Portal.Api.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }

        public Task SendEmailAsync(int employeeId, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
