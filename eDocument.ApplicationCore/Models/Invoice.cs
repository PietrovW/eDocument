using eDocument.ApplicationCore.Enums;
using eDocument.ApplicationCore.Models;
using eDocument.ApplicationCore.Models.Base;
using System;
using System.Collections.Generic;

namespace DocumentTracking.ApplicationCore.Entities
{
    public class Invoice: BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public TypeInvoiceEnum Type { get; set; }

        public DateTime DateReceived { get; set; }

        public long AttachmentId { get; set; }

        public string BarCode { get; set; }

        public Attachment Attachment { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }

        public List<Process> Process { get; set; }
    }
}


