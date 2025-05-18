using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Products.Queries.GetProductById;
public class GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductVm>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper; 

    public async Task<ProductVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetByIdAsync(request.Id);
        return _mapper.Map<ProductVm>(product);
    }
}
