using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Orders.Commands.CreateOrder;
public sealed record CreateOrderCommand(
    string ShippingAddress,
    int CustomerId,
    ICollection<OrderItemVm> OrderItems) : IRequest<OrderVm>;
