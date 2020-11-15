using Notifikation.Domain.Models;

namespace Notifikation.Infrastructure.Command
{
    public class CreateNotifikationCommand
    {
        public NotifikationModel Notifikation { get; set; }
    }
}
