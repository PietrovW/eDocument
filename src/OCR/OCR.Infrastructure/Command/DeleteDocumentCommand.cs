using MediatR;

namespace OCR.Infrastructure.Command
{
    public class DeleteDocumentCommand : IRequest
    {
        public long Id { get; set; }
    }
}
