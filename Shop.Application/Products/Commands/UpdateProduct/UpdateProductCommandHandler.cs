using AutoMapper;
using MediatR;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Products.Commands.UpdateProduct;
public class UpdateProductCommandHandler(IProductRepository repository, IMapper mapper)
    : IRequestHandler<UpdateProductCommand, int>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        return await _repository.UpdateAsync(request.Id, _mapper.Map<Product>(request));
    }
}
