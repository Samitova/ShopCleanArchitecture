using MediatR;
using Shop.Domain.Entities;

namespace Shop.Application.Orders.Commands.UpdateOrder;
public sealed record UpdateOrderCommand(
    int Id,    
    DateTime ShippedAt,
    string ShippingAddress,
    OrderStatus OrderStatus,
    int CustomerId) : IRequest<int>;
