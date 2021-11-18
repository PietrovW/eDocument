using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Notifikation.Infrastructure.Models;

namespace Notifikation.Infrastructure.Services
{
    public class EmailService : ISenderService
    {
        private readonly SmtpClient _client;
        public EmailService(SmtpClient client)
        {
            _client = client;
        }

        public async Task<ErrorResponseModel> SendAsync(string sender, string subject, string body)
        {

          await _client.SendMailAsync(sender, "recipient", subject, body);

            throw new NotImplementedException();
        }

        public async Task<ErrorResponseModel> SendAsync(string recepientName, string recepientEmail, string subject, string body)
        {
            ErrorResponseModel error = new ErrorResponseModel();
            throw new NotImplementedException();
        }

        public async Task<ErrorResponseModel> SendAsync(string senderName, string senderEmail, string recepientName, string recepientEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}
