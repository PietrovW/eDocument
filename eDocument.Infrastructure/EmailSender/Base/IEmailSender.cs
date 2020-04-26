using eDocument.Infrastructure.Options;
using MimeKit;
using System.Threading.Tasks;

namespace eDocument.Infrastructure.EmailSender.Base
{
    public interface IEmailSender
    {
        Task<(bool success, string errorMsg)> SendEmailAsync(MailboxAddress sender, MailboxAddress[] recepients, string subject, string body, SmtpOptions config = null, bool isHtml = true);
        Task<(bool success, string errorMsg)> SendEmailAsync(string recepientName, string recepientEmail, string subject, string body, SmtpOptions config = null, bool isHtml = true);
        Task<(bool success, string errorMsg)> SendEmailAsync(string senderName, string senderEmail, string recepientName, string recepientEmail, string subject, string body, SmtpOptions config = null, bool isHtml = true);
    }
}
