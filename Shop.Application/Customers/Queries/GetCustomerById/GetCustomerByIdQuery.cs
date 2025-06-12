using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Customers.Queries.GetCustomerById;
public record GetCustomerByIdQuery(int Id) : IRequest<CustomerVm>;