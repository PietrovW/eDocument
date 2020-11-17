using MediatR;
using Notifikation.Infrastructure.Command;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    public class DeleteNotifikationCommandHandler : IRequestHandler<DeleteNotifikationCommand, bool>
    {
        public Task<bool> Handle(DeleteNotifikationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
