using MediatR;

namespace Shop.Application.Customers.Commands.UpdateCustomer;
public record UpdateCustomerCommand(
    int Id,
    string FirstName,
    string LastName,
    string Address,
    string Email,
    string Phone) : IRequest<int>;
