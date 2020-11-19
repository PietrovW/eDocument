using eDocument.Infrastructure.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    public class SendNotifikationCommandHandler : IRequestHandler<SendNotifikationCommand, bool>
    {
        public Task<bool> Handle(SendNotifikationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
}
