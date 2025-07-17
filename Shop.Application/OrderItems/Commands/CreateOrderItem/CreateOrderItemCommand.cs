using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.OrderItems.Commands.CreateOrderItem;

public record class CreateOrderItemCommand(
    int OrderedQuantity,
    decimal UnitPrice,
    int ProductId,
    int OrderId) : IRequest<OrderItemVm>;