using MediatR;

namespace OCR.Infrastructure.Command
{
    using OCR.Infrastructure.DTO;
    public class CreateDocumentCommand : IRequest<DocumentDTO>
    {
        public long UserId { get; set; }
        public string FileName { get; set; }
        public byte[] Bytes {get;set;}
    }
}
