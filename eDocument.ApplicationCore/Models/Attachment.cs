using DocumentTracking.ApplicationCore.Entities;
using eDocument.ApplicationCore.Models.Base;
using System.Collections.Generic;

namespace eDocument.ApplicationCore.Models
{
    public class Attachment : BaseEntity
    {
        public long Id { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
