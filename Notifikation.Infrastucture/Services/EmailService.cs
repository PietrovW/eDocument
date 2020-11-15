using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Notifikation.Infrastructure.Models;

namespace Notifikation.Infrastructure.Services
{
    public class EmailService : ISenderService
    {
        public EmailService()
        {
            SmtpClient client = new SmtpClient();
        }

        public async Task<ErrorResponseModel> SendAsync(string sender, string subject, string body)
        {
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
