using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Customers.Queries.GetCustomers;
public record GetCustomersQuuery : IRequest<List<CustomerVm>>;
