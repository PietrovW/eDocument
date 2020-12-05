using eDocument.Infrastructure.Repositories;
using MediatR;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.Context;
using Notifikation.Infrastructure.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private IWriteIRepository notifikationWrite;
        public CreateUserCommandHandler(IWriteIRepository notifikationWrite)
        {
            this.notifikationWrite = notifikationWrite;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           
            return request.User;
        }
    }
}
