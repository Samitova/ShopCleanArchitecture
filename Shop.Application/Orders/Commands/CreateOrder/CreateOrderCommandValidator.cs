using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.Orders.Commands.CreateOrder;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    private readonly ICustomerRepository _repository;

    public CreateOrderCommandValidator(ICustomerRepository repository)
    {
        _repository = repository;

        RuleFor(v => v.ShippingAddress)
            .NotEmpty().WithMessage("ShippingAddress field is required");

        RuleFor(v => v.CustomerId)
           .NotEmpty().WithMessage("CustomerId field is required");

        // Is it possible to check OrderItems information?
        RuleFor(v => v.OrderItems)
           .NotEmpty().WithMessage("OrderItems field is required");

        RuleFor(ws => ws)
          .MustAsync((x, cancellation) => EntityExists(x.CustomerId))
          .WithMessage($"Customer with CustomerId was not found.");
    }

    private async Task<bool> EntityExists(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;
        return true;
    }
}
