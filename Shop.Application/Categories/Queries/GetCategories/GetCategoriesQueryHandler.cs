using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Categories.Queries.GetCategories;
public class GetCategoriesQueryHandler(ICategoryRepository repository, IMapper mapper)
    : IRequestHandler<GetCategoriesQuery, List<CategoryVm>>
{
    public async Task<List<CategoryVm>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync();

        return mapper.Map<List<CategoryVm>>(categories);
    }
}
