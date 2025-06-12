namespace Shop.Domain.Entities
{
    public class OrderItem
    {
        public int OrderedQuantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int OrderId { get; set; }       
        public Order Order { get; set; }
    }
}
