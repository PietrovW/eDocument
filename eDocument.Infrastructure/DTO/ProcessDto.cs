using DocumentTracking.ApplicationCore.Entities;
using eDocument.ApplicationCore.Enums;

namespace eDocument.Infrastructure.DTO
{
    public class ProcessDto
    {
        public long Id { get; set; }
        public long InvoiceId { get; set; }

        public Invoice Invoice { get; set; }

        public string Name { get; set; }

        public TypeStatusEnum Status { get; set; }
    }
}
