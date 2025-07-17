using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.OrderItems.Commands.CreateOrderItem;
public class CreateOrderItemCommandValidator : AbstractValidator<CreateOrderItemCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;

    public CreateOrderItemCommandValidator(IOrderRepository orderRepository, IProductRepository productRepository)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;        

        RuleFor(v => v.UnitPrice)
            .GreaterThan(0).WithMessage("Price should be greater than 0");

        RuleFor(v => v.OrderedQuantity)
            .GreaterThan(0).WithMessage("Product quantity should be greater than 0");

        RuleFor(ws => ws)
            .MustAsync((x, cancellation) => OrderExists(x.OrderId))
            .WithMessage(x => $"Order with order id {x.OrderId} was not found.");

        RuleFor(ws => ws)
            .MustAsync((x, cancellation) => ProductExists(x.ProductId))
            .WithMessage(x => $"Product  with product id {x.ProductId} was not found.");
    }

    private async Task<bool> OrderExists(int orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order is null) return false;
        return true;
    }

    private async Task<bool> ProductExists(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId);
        if (product is null) return false;
        return true;
    }
}