using eDocument.ApplicationCore.Models.Base;
using System;
using System.Collections.Generic;

namespace eDocument.ApplicationCore.Models
{
    public class ProductCategory : BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
