using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.QuerieHandler
{
    using Notifikation.Infrastructure.DTO;
    using Notifikation.Infrastructure.Queries;
    using eDocument.Infrastructure.Repositories;
    public class GetUserQuerieHandler : IRequestHandler<GetUserQueries, UserDTO>
    {
        private IWriteIRepository notifikationWrite;
        public GetUserQuerieHandler(IWriteIRepository notifikationWrite)
        {
            this.notifikationWrite = notifikationWrite;
        }

        public async Task<UserDTO> Handle(GetUserQueries request, CancellationToken cancellationToken)
        {
         
            return null;
        }
    }
}
