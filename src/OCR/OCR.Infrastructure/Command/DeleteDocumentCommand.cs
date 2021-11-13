using MediatR;

namespace OCR.Infrastructure.Command
{
    public class DeleteDocumentCommand : IRequest
    {
        public long UserId { get; set; }
    }
}
