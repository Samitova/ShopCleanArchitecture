using MediatR;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.OrderItems.Commands.UpdateOrderItem;
public class UpdateOrderItemCommandHandler(IOrderItemRepository repository)
    : IRequestHandler<UpdateOrderItemCommand, int>
{
    private readonly IOrderItemRepository _repository = repository;

    public async Task<int> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItem = new OrderItem
        {
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            UnitPrice = request.UnitPrice,
            OrderedQuantity = request.OrderedQuantity
        };

        return await _repository.UpdateAsync(request.OrderId, request.ProductId, orderItem);
    }
}