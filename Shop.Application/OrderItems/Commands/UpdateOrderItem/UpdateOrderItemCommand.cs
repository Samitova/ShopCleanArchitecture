using MediatR;

namespace Shop.Application.OrderItems.Commands.UpdateOrderItem;
public record UpdateOrderItemCommand(
    int OrderedQuantity,
    decimal UnitPrice,
    int ProductId,
    int OrderId) : IRequest<int>;