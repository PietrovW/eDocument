using MediatR;

namespace Notifikation.Infrastructure.Command
{
    public class DeleteNotifikationCommand: IRequest<bool>
    {
        public long Id { get; set; }
    }
}
