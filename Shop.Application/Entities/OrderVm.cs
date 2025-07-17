using Shop.Domain.Entities;
using System.Text.Json.Serialization;

namespace Shop.Application.Entities;
public class OrderVm
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ShippedAt { get; set; }
    public string ShippingAddress { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public int CustomerId { get; set; }
    public virtual ICollection<OrderItemVm> OrderItems { get; set; }
}
