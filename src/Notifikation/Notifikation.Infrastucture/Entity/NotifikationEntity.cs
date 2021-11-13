using eDocument.Infrastructure.Entity;

namespace Notifikation.Infrastructure.Entity
{
    public class NotifikationEntity : BaseEntity
    {
        public UserEntity User { get; set; }
        
        public string Message { get; set; }
    }
}
