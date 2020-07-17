using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Enums
{
    public enum PaymentMethod : int
    {
        Check = 1,
        BankTransfer = 2,
        Cash = 3,
        Paypal = 4,
        Payoneer = 5
    }
}
