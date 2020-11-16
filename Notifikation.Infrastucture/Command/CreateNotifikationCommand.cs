using Notifikation.Domain.Models;
using Notifikation.Infrastructure.DTO;

namespace Notifikation.Infrastructure.Command
{
    public class CreateNotifikationCommand
    {
        public NotifikatItemDTO Notifikation { get; set; }
    }
}
