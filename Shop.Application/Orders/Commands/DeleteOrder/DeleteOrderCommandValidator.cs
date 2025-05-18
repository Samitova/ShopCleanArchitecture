using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.Orders.Commands.DeleteOrder;
public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    private readonly IOrderRepository _repository;
    public DeleteOrderCommandValidator(IOrderRepository repository)
    {
        _repository = repository;

        RuleFor(ws => ws)
            .MustAsync((x, cancellation) => EntityExists(x.Id))
            .WithMessage("Order was not found.");
    }

    private async Task<bool> EntityExists(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;
        return true;
    }
}
