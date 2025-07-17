using MediatR;

namespace Shop.Application.OrderItems.Commands.DeleteOrderItem;
public record DeleteOrderItemCommand(int OrderId, int ProductId) : IRequest<int>;