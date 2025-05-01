using System.Text.Json.Serialization;

namespace Shop.Domain.Entities
{
    public class Order
    {       
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ShippedAt { get; set; }
        public Address ShippingAddress { get; set; }
        public OrderStatus OrderStatus { get; set; }   
        
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [JsonIgnore]
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
