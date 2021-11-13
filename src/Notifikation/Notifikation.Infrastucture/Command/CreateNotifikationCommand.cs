using MediatR;
using Notifikation.Infrastructure.DTO;

namespace Notifikation.Infrastructure.Command
{
    public class CreateNotifikationCommand: IRequest<NotifikatItemDTO> 
    {
        public NotifikatItemDTO Notifikation { get; set; }
    }
}
