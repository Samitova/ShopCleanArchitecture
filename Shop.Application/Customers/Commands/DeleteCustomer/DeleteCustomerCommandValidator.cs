using FluentValidation;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Domain.Contracts;
namespace Shop.Application.Customers.Commands.DeleteCustomer;
public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    private readonly ICustomerRepository _repository;
    public DeleteCustomerCommandValidator(ICustomerRepository repository)
    {
        _repository = repository;

        RuleFor(ws => ws)
            .MustAsync((x, cancellation) => EntityExists(x.Id))
            .WithMessage("Customer was not found.");
    }

    private async Task<bool> EntityExists(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;
        return true;
    }
}
