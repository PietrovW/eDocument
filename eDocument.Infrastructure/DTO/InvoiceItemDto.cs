using DocumentTracking.ApplicationCore.Entities;
using eDocument.ApplicationCore.Enums;

namespace eDocument.Infrastructure.DTO
{
    public class InvoiceItemDto
    {
        public long InvoiceId { get; set; }

        public decimal NetAmount { get; set; }

        public decimal GrossAmount { get; set; }

        public decimal TaxRate { get; set; }

        public decimal VATNumberProvider { get; set; }

        public decimal BankAccount { get; set; }

        public TypePaymentEnum PaymentMethod { get; set; }

        public Invoice Invoice { get; set; }
    }
}
