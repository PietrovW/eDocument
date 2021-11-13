using eDocument.Domain.Enums;
using MediatR;

namespace eDocument.Infrastructure.Command
{
    public class SendNotifikationCommand: IRequest<bool>
    {
        public NotifikationEnum NotifikationEnum { get; set; }
        public string Name { get; set; }
    }
}
