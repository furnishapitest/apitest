using EuroFurnish.ApplicationCore.Entities.Base;
using EuroFurnish.ApplicationCore.Enums;
using System.Collections.Generic;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; }
        public decimal GrandTotal { get; set; }
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public long BillingAddressId { get; set; }
        public Address BillingAddress { get; set; }
        public long ShippingAddressId { get; set; }
        public Address ShippingAddress { get; set; }        
        public ICollection<OrderItem> Items { get; set; }

    }
}
