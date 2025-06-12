namespace Shop.Application.Entities;
public class OrderItemVm
{
    public int OrderedQuantity { get; set; }
    public decimal UnitPrice { get; set; }
    public int ProductId { get; set; }
    public int OrderId { get; set; }
}
