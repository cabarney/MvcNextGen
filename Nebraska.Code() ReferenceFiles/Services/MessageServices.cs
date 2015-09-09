using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Framework.Configuration;
using Twilio;

namespace Nebraska.Code.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        private readonly IConfiguration _configuration;

        public AuthMessageSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var msg = new MailMessage(new MailAddress("info@nebraskacode.com"), new MailAddress(email))
            {
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };

            var client = new SmtpClient
            {
                Host = _configuration["Smtp:Host"],
                Port = Int32.Parse(_configuration["Smtp:Port"]),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_configuration["Smtp:Username"], _configuration["Smtp:Password"])
            };

            client.Send(msg);
            return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            var twilio = new TwilioRestClient(_configuration["Twilio:AccountSid"], _configuration["Twilio:AuthToken"]);
            var result = twilio.SendMessage(_configuration["Twilio:Number"], number, message);
            return Task.FromResult(0);
        }
    }
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
