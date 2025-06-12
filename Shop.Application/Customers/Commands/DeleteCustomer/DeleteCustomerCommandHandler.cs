using MediatR;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Domain.Contracts;

namespace Shop.Application.Customers.Commands.DeleteCustomer;
public class DeleteCustomerCommandHandler(ICustomerRepository repository)
    : IRequestHandler<DeleteCustomerCommand, int>
{
    private readonly ICustomerRepository _repository = repository;
    public async Task<int> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
