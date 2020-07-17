using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class OrderPaymentAssociation : BaseIdEntity
    {
        public OrderPaymentAssociation(long orderId, long paymentId)
        {
            OrderId = orderId;
            PaymentId = paymentId;
        }

        public long OrderId { get; set; }
        public Order Order { get; set; }
        public long PaymentId { get; set; }
        public Payment Payment { get; set; }
        
    }
}
