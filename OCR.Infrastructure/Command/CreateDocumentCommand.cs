using MediatR;
using OCR.Infrastructure.DTO;

namespace OCR.Infrastructure.Command
{
    public class CreateDocumentCommand : IRequest<DocumentDTO>
    {
        public long UserId { get; set; }
        public string FileName { get; set; }
        public byte[] Bytes {get;set;}
    }
}
