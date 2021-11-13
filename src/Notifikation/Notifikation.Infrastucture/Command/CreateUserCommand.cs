using MediatR;
using Notifikation.Infrastructure.DTO;

namespace Notifikation.Infrastructure.Command
{
    public class CreateUserCommand : IRequest<UserDTO>
    {
        public UserDTO User { get; set; }
    }
}
