using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OCR.Infrastructure.CommandHandler
{
    using OCR.Infrastructure.Command;
    public class DeleteDocumentCommandHandler : IRequestHandler<DeleteDocumentCommand>
    {
        public Task<Unit> Handle(DeleteDocumentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
