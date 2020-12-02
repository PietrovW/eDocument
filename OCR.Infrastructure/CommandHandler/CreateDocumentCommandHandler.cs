using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace OCR.Infrastructure.CommandHandler
{
    using OCR.Infrastructure.Command;
    using OCR.Infrastructure.DTO;
    using OCR.Infrastructure.Services;

    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, DocumentDTO>
    {
        private IOCRService _ocrService;
        public CreateDocumentCommandHandler(IOCRService ocrService)
        {
            _ocrService = ocrService;
        }
        public async Task<DocumentDTO> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
           await Task.Run(() =>
           {
               DocumentDTO documentDTO = new DocumentDTO();
               documentDTO.FileName = documentDTO.FileName;
               documentDTO.UserId = request.UserId;
               documentDTO.Content = _ocrService.GetText(request.Bytes);
               return documentDTO;
           });

            return null;
        }
    }
}
