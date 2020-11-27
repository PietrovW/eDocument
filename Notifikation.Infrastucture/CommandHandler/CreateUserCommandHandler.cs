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
        private INotifikationWriteContext notifikationWrite;
        public CreateUserCommandHandler(INotifikationWriteContext notifikationWrite)
        {
            this.notifikationWrite = notifikationWrite;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string sql = string.Empty;
            await notifikationWrite.ExecuteAsync(sql);
            return request.User;
        }
    }
}
