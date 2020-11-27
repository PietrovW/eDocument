using MediatR;
using Notifikation.Infrastructure.DTO;

namespace Notifikation.Infrastructure.Queries
{
    public class GetUserQueries : IRequest<UserDTO>
    {
        public long Id { get; set; }
    }
}
