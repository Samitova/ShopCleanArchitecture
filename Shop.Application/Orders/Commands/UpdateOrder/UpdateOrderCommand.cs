using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Entities;

namespace Shop.Application.Orders.Commands.UpdateOrder;
public sealed record UpdateOrderCommand(
    int Id,
    //Is it possible to update this param
    DateTime CreatedAt,    
    DateTime ShippedAt,
    Address ShippingAddress,
    OrderStatus OrderStatus,
    int CustomerId,    
    ICollection<OrderItemVm> OrderItems) : IRequest<int>;
