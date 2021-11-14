using AutoMapper;
using eDocument.Infrastructure.Repositories;
using eDocument.Infrastructure.Specification;
using MediatR;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Entity;
using Notifikation.Infrastructure.Exceptions;
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

            if (!_readRepository.Contains(new ContainsSpecification(notifikationEntity)))
            {
                _notifikationWrite.Add<NotifikationEntity>(notifikationEntity);
                await _notifikationWrite.SaveChangesAsync();
            }
            else
            {
                throw new ExistsNotifikatInfrastructureException($"Message: {notifikationEntity.Message} User : {notifikationEntity.User}");
            }
           var notifikatItemDTO = _mapper.Map<NotifikatItemDTO>(notifikationEntity);
            return notifikatItemDTO;
        }

    }
    public class ContainsSpecification : BaseSpecification<NotifikationEntity>
    {
        public ContainsSpecification(NotifikationEntity notifikationEntity) :
            base(notifikationEntity => notifikationEntity.Message.Contains(notifikationEntity.Message)
                && notifikationEntity.User == notifikationEntity.User)
        {
        }
    }
}
