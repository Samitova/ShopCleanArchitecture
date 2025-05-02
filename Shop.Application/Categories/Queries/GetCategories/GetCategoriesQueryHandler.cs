using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Categories.Queries.GetCategories;
public class GetCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
    : IRequestHandler<GetCategoriesQuery, List<CategoryVm>>
{
    private readonly ICategoryRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CategoryVm>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _repository.GetAllAsync();

        return _mapper.Map<List<CategoryVm>>(categories);
    }
}
