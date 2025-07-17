using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.OrderItems.Queries.GetOrderItemsByProductId;

public record GetOrderItemsByProductIdQuery(int ProductId) : IRequest<List<OrderItemVm>>;
