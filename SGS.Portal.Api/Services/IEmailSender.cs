using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGS.Portal.Api.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);

        Task SendEmailAsync(int employeeId, string subject, string message);
    }
}
