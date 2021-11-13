using System.Collections.Generic;

namespace Notifikation.Domain.Models
{
    public class User: BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Notifikation> Notifikations { get; set; }
}
}
