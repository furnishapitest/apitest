using EuroFurnish.ApplicationCore.Entities.Base;

namespace EuroFurnish.ApplicationCore.Entities
{
    public class OrderItem : BaseEntity
    {
        public OrderItem(int quantity, string color, decimal unitPrice, decimal totalPrice, int productId)
        {
            Quantity = quantity;
            Color = color;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
            ProductId = productId;
        }

        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
