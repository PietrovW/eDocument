
using eDocument.Infrastructure.Entity;

namespace Notifikation.Infrastructure.Entity
{
    public class UserEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
