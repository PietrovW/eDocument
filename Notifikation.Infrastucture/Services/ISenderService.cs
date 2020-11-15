using System.Threading.Tasks;
using Notifikation.Infrastructure.Models;

namespace Notifikation.Infrastructure.Services
{
    public interface ISenderService
    {
        Task<ErrorResponseModel> SendAsync(string sender, string subject, string body);
        Task<ErrorResponseModel> SendAsync(string recepientName, string recepientEmail, string subject, string body);
        Task<ErrorResponseModel> SendAsync(string senderName, string senderEmail, string recepientName, string recepientEmail, string subject, string body);
    }
}
