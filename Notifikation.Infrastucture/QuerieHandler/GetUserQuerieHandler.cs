using MediatR;
using Notifikation.Infrastructure.Command;
using Notifikation.Infrastructure.Context;
using Notifikation.Infrastructure.DTO;
using Notifikation.Infrastructure.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Notifikation.Infrastructure.QuerieHandler
{
    public class GetUserQuerieHandler : IRequestHandler<GetUserQueries, UserDTO>
    {
        private INotifikationWriteContext notifikationWrite;
        public GetUserQuerieHandler(INotifikationWriteContext notifikationWrite)
        {
            this.notifikationWrite = notifikationWrite;
        }

        public async Task<UserDTO> Handle(GetUserQueries request, CancellationToken cancellationToken)
        {
            string sql = string.Empty;
            await notifikationWrite.ExecuteAsync(sql);
            return null;
        }
    }
}
