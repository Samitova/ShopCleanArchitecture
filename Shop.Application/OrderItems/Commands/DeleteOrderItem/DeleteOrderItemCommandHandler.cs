using MediatR;
using Shop.Domain.Contracts;

namespace Shop.Application.OrderItems.Commands.DeleteOrderItem;

public class DeleteOrderItemCommandHandler(IOrderItemRepository repository)
    : IRequestHandler<DeleteOrderItemCommand, int>
{
    private readonly IOrderItemRepository _repository = repository;

    public async Task<int> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.OrderId, request.ProductId);
    }
}