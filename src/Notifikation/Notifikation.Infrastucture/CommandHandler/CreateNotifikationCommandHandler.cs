using AutoMapper;
using eDocument.Infrastructure.Repositories;
using eDocument.Infrastructure.Specification;
using MediatR;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    public class CreateNotifikationCommandHandler : IRequestHandler<CreateNotifikationCommand, NotifikatItemDTO>
    {
        private IWriteIRepository _notifikationWrite;
        private IReadRepository _readRepository;
        private IMapper _mapper;
        public CreateNotifikationCommandHandler(IWriteIRepository notifikationWrite, IReadRepository readRepository, IMapper mapper)
        {
            _notifikationWrite = notifikationWrite;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<NotifikatItemDTO> Handle(CreateNotifikationCommand request, CancellationToken cancellationToken)
        {
           var notifikationEntity = _mapper.Map<NotifikationEntity>(request);

            ISpecification<NotifikationEntity> samsungExpSpec =    new ExpressionSpecification<NotifikationEntity>(o => o.BrandName == BrandName.Samsung);
            if (_readRepository.Contains<NotifikationEntity>(SpecificationEvaluator))
            {

            }



            return request.Notifikation;
        }

       
    }
}
