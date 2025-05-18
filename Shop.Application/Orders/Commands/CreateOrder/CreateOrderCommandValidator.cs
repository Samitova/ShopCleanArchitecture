using FluentValidation;

namespace Shop.Application.Orders.Commands.CreateOrder;
public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(v => v.ShippingAddress)
            .NotEmpty().WithMessage("ShippingAddress field is required");

        RuleFor(v => v.CustomerId)
           .NotEmpty().WithMessage("CustomerId field is required");

        // Is it possible to check OrderItems information?
        RuleFor(v => v.OrderItems)
           .NotEmpty().WithMessage("OrderItems field is required");
    }
}
