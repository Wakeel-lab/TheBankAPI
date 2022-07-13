using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBankAPI.Services.Utilities
{
    public interface IEmailSender
    {
        Task SendEmail(string sourceAddress, string destinationAddress, string subject, string message);
    }
}
