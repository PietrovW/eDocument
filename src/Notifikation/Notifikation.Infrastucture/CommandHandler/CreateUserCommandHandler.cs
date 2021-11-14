using AutoMapper;
using eDocument.Infrastructure.Repositories;
using eDocument.Infrastructure.Specification;
using MediatR;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.Context;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Entity;
using Notifikation.Infrastructure.Exceptions;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.CommandHandler
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDTO>
    {
        private IWriteIRepository _notifikationWrite;
        private IReadRepository _readRepository;
        private IMapper _mapper;

        public CreateUserCommandHandler(IWriteIRepository notifikationWrite, IReadRepository readRepository, IMapper mapper)
        {
            _notifikationWrite = notifikationWrite;
            _readRepository = readRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var userEntity = _mapper.Map<UserEntity>(request);

            if (!_readRepository.Contains(new ContainsUserSpecification(userEntity)))
            {
                _notifikationWrite.Add<UserEntity>(userEntity);
                await _notifikationWrite.SaveChangesAsync();
            }
            else
            {
                throw new NoExistsUserInfrastructureException($"Email: {userEntity.Email} Name : {userEntity.Name}");
            }
            var userDTO = _mapper.Map<UserDTO>(userEntity);
            return userDTO;
        }
    }

    public class ContainsUserSpecification : BaseSpecification<UserEntity>
    {
        public ContainsUserSpecification(UserEntity user) :
            base(notifikationEntity => notifikationEntity.Email.Contains(user.Email))
        {
        }
    }
}
