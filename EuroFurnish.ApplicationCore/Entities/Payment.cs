using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class Payment : BaseEntity
    {
        public Payment(decimal grandTotal)
        {
            GrandTotal = grandTotal;
        }

        public decimal GrandTotal { get; set; }
        public ICollection<PaymentItem> Items { get; set; } 
    }
}
