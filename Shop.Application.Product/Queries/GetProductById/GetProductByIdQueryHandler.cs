using AutoMapper;
using MediatR;
using Shop.Application.Product.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Product.Queries.GetProductById;
public class GetProductByIdQueryHandler(IProductRepository repository, IMapper mapper)
    : IRequestHandler<GetProductByIdQuery, ProductVm>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper; 
    public Task<ProductVm> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
