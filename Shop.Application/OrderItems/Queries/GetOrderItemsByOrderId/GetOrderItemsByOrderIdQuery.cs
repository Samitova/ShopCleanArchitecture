using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.OrderItems.Queries.GetOrderItems;

public record GetOrderItemsByOrderIdQuery(int OrderId) : IRequest<List<OrderItemVm>>;
