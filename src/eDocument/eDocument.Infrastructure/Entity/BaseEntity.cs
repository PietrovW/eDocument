using System;

namespace eDocument.Infrastructure.Entity
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public uint xmin { get; set; }

        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateUpdate { get; set; }
    }
}
