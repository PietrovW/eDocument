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
        private INotifikationWriteContext notifikationWrite;
        public CreateNotifikationCommandHandler(INotifikationWriteContext notifikationWrite)
        {
            this.notifikationWrite = notifikationWrite;
        }

        public async Task<NotifikatItemDTO> Handle(CreateNotifikationCommand request, CancellationToken cancellationToken)
        {
            string sql = string.Empty;
            await notifikationWrite.ExecuteAsync(sql);
            return request.Notifikation;
        }
    }
}
