using MediatR;
using Shop.Domain.Contracts;

namespace Shop.Application.Categories.Queries.GetCategories;
public class GetCategoryQueryHandler(ICategoryRepository repository) : IRequestHandler<GetCategoryQuery, List<CategoryVm>>
{
    public async Task<List<CategoryVm>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await repository.GetAllAsync();

        return categories.Select(x => new CategoryVm {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Products = x.Products
        }).ToList();
    }
}
