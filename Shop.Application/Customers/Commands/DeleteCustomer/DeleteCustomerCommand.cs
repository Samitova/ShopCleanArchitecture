using MediatR;

namespace Shop.Application.Customers.Commands.DeleteCustomer;

public sealed record DeleteCustomerCommand(int Id) : IRequest<int>;