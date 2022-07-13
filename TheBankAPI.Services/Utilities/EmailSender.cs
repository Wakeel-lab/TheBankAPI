using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBankAPI.Services.Utilities
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public EmailSender(IConfiguration config)
        {
            _config = config;
        }

        public Task SendEmail(string sourceAddress, string destinationAddress, string subject, string message)
        {
            var emailSend = new MimeMessage();

            emailSend.From.Add(MailboxAddress.Parse("sourceAddress"));
            emailSend.To.Add(MailboxAddress.Parse("destinationAddress"));
            emailSend.Subject = subject;
            emailSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using var client = new SmtpClient();

            client.Connect(_config.GetSection("Host").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate(_config.GetSection("Username").Value, _config.GetSection("Password").Value);
            client.Send(emailSend);
            client.Disconnect(true);

            return Task.CompletedTask;

        }
    }
}
