using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.OrderItems.Commands.DeleteOrderItem;
public class DeleteOrderItemCommandValidator : AbstractValidator<DeleteOrderItemCommand>
{
    private readonly IOrderItemRepository _repository;

    public DeleteOrderItemCommandValidator(IOrderItemRepository repository)
    {
        _repository = repository;

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