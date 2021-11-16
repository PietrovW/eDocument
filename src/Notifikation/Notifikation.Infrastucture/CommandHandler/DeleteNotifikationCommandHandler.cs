using AutoMapper;
using eDocument.Infrastructure.Repositories;
using eDocument.Infrastructure.Specification;
using MediatR;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.Entity;
using Notifikation.Infrastructure.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    public class DeleteNotifikationCommandHandler : IRequestHandler<DeleteNotifikationCommand, bool>
    {
        private IWriteIRepository _notifikationWrite;
        private IReadRepository _readRepository;
        private IMapper _mapper;

        public DeleteNotifikationCommandHandler(IWriteIRepository notifikationWrite, IReadRepository readRepository, IMapper mapper)
        {
            _notifikationWrite = notifikationWrite;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteNotifikationCommand request, CancellationToken cancellationToken)
        {
            NotifikationEntity notifikationEntity = _readRepository.FindSingle(new ContainsSpecification(request.Id));
            if (notifikationEntity != null)
            {

                _notifikationWrite.Remove(notifikationEntity);
                await _notifikationWrite.SaveChangesAsync();
            }
            else
            {
                throw new NoExistsNotifikatInfrastructureException($"Id: {request.Id}");
            }

            return true;
        }

        public class ContainsSpecification : BaseSpecification<NotifikationEntity>
        {
            public ContainsSpecification(long Id) :
                base(notifikationEntity => notifikationEntity.Id == Id)

            {
            }
        }
    }
}
