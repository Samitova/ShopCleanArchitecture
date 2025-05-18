using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Products.Queries.GetProducts;
public class GetProductsQueryHandler(IProductRepository repository, IMapper mapper) 
    : IRequestHandler<GetProductsQuery, List<ProductVm>>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<ProductVm>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _repository.GetAllAsync();

        return _mapper.Map<List<ProductVm>>(products);
    }
}
