using eDocument.ApplicationCore.Models.Base;
using System;
using System.Collections.Generic;

namespace eDocument.ApplicationCore.Models
{
    public class Order : BaseEntity
    {
        public long Id { get; set; }
        public decimal Discount { get; set; }
        public string Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public string CashierId { get; set; }
        public ApplicationUser Cashier { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
