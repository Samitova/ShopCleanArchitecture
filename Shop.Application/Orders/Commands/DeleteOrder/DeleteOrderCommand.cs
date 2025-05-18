using MediatR;

namespace Shop.Application.Orders.Commands.DeleteOrder;
public sealed record DeleteOrderCommand(int Id): IRequest<int>;
