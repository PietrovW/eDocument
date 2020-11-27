using MediatR;

namespace Notifikation.Infrastructure.Command
{
    public class DeleteUserCommand: IRequest<bool>
    {
        public long Id { get; set; }
    }
}
