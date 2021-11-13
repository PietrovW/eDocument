using eDocument.Infrastructure.Repositories;
using MediatR;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.Context;
using Notifikation.Infrastructure.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    public class CreateNotifikationCommandHandler : IRequestHandler<CreateNotifikationCommand, NotifikatItemDTO>
    {
        private IWriteIRepository notifikationWrite;
        public CreateNotifikationCommandHandler(IWriteIRepository notifikationWrite)
        {
            this.notifikationWrite = notifikationWrite;
        }

        public async Task<NotifikatItemDTO> Handle(CreateNotifikationCommand request, CancellationToken cancellationToken)
        {
            
            return request.Notifikation;
        }
    }
}
