using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Customers.Commands.CreateCustomer;
public record CreateCustomerCommand(
    string FirstName,
    string LastName,
    string Address,
    string Email,
    string Phone) : IRequest<CustomerVm>;