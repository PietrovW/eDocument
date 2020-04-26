using eDocument.ApplicationCore.Enums;
using System;

namespace eDocument.Infrastructure.DTO
{
    public class InvoiceDto
    {
        public string Name { get; set; }
        public TypeInvoiceEnum Type { get; set; }

        public DateTime Date_Received { get; set; }

        public long AttachmentId { get; set; }

        public string BarCode { get; set; }
    }
}
