using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace OCR.Infrastructure.CommandHandler
{
    using AutoMapper;
    using eDocument.Infrastructure.Repositories;
    using OCR.Infrastructure.Command;
    using OCR.Infrastructure.DTO;
    using OCR.Infrastructure.Entitys;
    using OCR.Infrastructure.Services;

    public class CreateDocumentCommandHandler : IRequestHandler<CreateDocumentCommand, DocumentDTO>
    {
        private IOCRService _ocrService;
        private IWriteIRepository _writeIRepository;
        private IMapper _mapper;
        public CreateDocumentCommandHandler(IOCRService ocrService,
            IWriteIRepository writeIRepository,
            IMapper mapper)
        {
            _ocrService = ocrService;
            _writeIRepository = writeIRepository;
            _mapper = mapper;
        }
        public async Task<DocumentDTO> Handle(CreateDocumentCommand request, CancellationToken cancellationToken)
        {
            var documentDTO = new DocumentDTO();
            documentDTO.FileName = documentDTO.FileName;
            documentDTO.UserId = request.UserId;
            documentDTO.Content = _ocrService.GetText(request.Bytes);
            var documentEntity = _mapper.Map<DocumentEntity>(documentDTO);

            _writeIRepository.Add(documentEntity);
            await _writeIRepository.SaveChangesAsync();
            return documentDTO;
        }
    }
}
