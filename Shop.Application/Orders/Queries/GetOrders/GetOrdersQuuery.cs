using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Orders.Queries.GetOrders;
public record GetOrdersQuuery: IRequest<List<OrderVm>>;
