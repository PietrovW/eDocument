using DocumentTracking.ApplicationCore.Entities;
using eDocument.ApplicationCore.Enums;
using eDocument.ApplicationCore.Models.Base;

namespace eDocument.ApplicationCore.Models
{
   public class Process : BaseEntity
   {
        public long Id { get; set; }
        public long InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string Name { get; set; }

        public TypeStatusEnum Status { get; set; }
    }
}
