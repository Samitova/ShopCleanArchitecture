using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Entities;

namespace Shop.Application.Orders.Commands.CreateOrder;
public sealed record CreateOrderCommand(
    int Id,
    //Init with what??
    DateTime ShippedAt,
    Address ShippingAddress,
    int CustomerId,
    //When this data will be insert in db?
    ICollection<OrderItemVm> OrderItems) : IRequest<OrderVm>;
