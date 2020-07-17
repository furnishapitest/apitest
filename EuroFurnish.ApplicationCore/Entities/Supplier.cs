using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class Supplier : BaseEntity
    {
        public string Title { get; set; }
        public string Brand { get; set; }
        public string TaxOffice { get; set; }
        public string TaxNo { get; set; }
        public long AddressId { get; set; }
        public Address Address { get; set; }
        public long ContactId { get; set; }
        public Contact Contact { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
