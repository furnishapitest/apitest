using EuroFurnish.ApplicationCore.Entities.Base;
using EuroFurnish.ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class PaymentItem : BaseEntity
    {
        public PaymentItem(decimal amount, PaymentMethod method)
        {
            Amount = amount;
            Method = method;
        }

        public decimal Amount { get; set; }

        public PaymentMethod Method { get; set; }
    }
}
