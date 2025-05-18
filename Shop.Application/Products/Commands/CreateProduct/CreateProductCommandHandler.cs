using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Products.Commands.CreateProduct;
public class CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
    :IRequestHandler<CreateProductCommand,ProductVm>
{
    private readonly IProductRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<ProductVm> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.CreateAsync(_mapper.Map<Product>(request));

        return _mapper.Map<ProductVm>(product);
    }
}
