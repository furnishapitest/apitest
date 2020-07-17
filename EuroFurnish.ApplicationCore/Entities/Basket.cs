using EuroFurnish.ApplicationCore.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class Basket : BaseEntity
    {
        //Application UserId eklenecek

        public ICollection<BasketItem> Items { get; set; }
    }
}
