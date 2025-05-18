using MediatR;
using Shop.Domain.Contracts;

namespace Shop.Application.Orders.Commands.DeleteOrder;
public class DeleteOrderCommandHandler(IOrderRepository repository) 
    : IRequestHandler<DeleteOrderCommand, int>
{
    private readonly IOrderRepository _repository = repository;
    public async Task<int> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
