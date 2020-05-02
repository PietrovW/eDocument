using eDocument.ApplicationCore.Models;
using eDocument.Infrastructure.Data;
using eDocument.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace eDocument.Infrastructure.Repositories
{
    public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
