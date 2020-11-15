using Notifikation.Domain.Models;

namespace Notifikation.Infrastructure.Command
{
    public class DeleteNotifikationCommand
    {
        public NotifikationModel Notifikation { get; set; }
    }
}
