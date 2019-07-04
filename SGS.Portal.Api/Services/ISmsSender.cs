using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGS.Portal.Api.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string phoneNumber, string message);
    }
}
