using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.OrderItems.Queries.GetOrderItemById;
public record GetOrderItemByIdQuery(int OrderId, int ProductId) : IRequest<OrderItemVm>;
