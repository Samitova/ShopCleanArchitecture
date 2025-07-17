using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.OrderItems.Commands.UpdateOrderItem;
public class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderItemCommand>
{
    private readonly IOrderItemRepository _repository;

    public UpdateOrderItemCommandValidator(IOrderItemRepository repository)
    {
        _repository = repository;

        RuleFor(v => v.UnitPrice)
            .GreaterThan(0).WithMessage("Price should be greater than 0");

        RuleFor(v => v.OrderedQuantity)
            .GreaterThan(0).WithMessage("Product quantity should be greater than 0");

        RuleFor(ws => ws)
           .MustAsync((x, cancellation) => OrderExists(x.OrderId))
           .WithMessage(x => $"OrderItem with order id {x.OrderId} was not found.");

        RuleFor(ws => ws)
            .MustAsync((x, cancellation) => ProductExists(x.ProductId))
            .WithMessage(x => $"OrderItem with product id {x.ProductId} was not found.");
    }

    private async Task<bool> OrderExists(int orderId)
    {
        var orderItems = await _repository.GetByOrderIdAsync(orderId);
        if (orderItems is null || !orderItems.Any()) return false;
        return true;
    }

    private async Task<bool> ProductExists(int productId)
    {
        var orderItems = await _repository.GetByProductIdAsync(productId);
        if (orderItems is null || !orderItems.Any()) return false;
        return true;
    }
}