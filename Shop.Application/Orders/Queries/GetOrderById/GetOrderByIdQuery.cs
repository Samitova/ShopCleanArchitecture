using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Orders.Queries.GetOrderById;
public sealed record GetOrderByIdQuery(int Id): IRequest<OrderVm>;
