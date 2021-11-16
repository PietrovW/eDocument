using AutoMapper;
using eDocument.Infrastructure.Repositories;
using MediatR;
using Notifikation.Infrastructure.Command;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private IWriteIRepository _notifikationWrite;
        private IReadRepository _readRepository;
        private IMapper _mapper;

        public Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
