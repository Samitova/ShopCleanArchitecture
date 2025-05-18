using MediatR;
using Shop.Domain.Contracts;

namespace Shop.Application.Products.Commands.DeleteProduct;
public class DeleteProductCommandHandler(IProductRepository repository) 
    : IRequestHandler<DeleteProductCommand, int>
{
    private readonly IProductRepository _repository = repository;
    public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}
