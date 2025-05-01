using MediatR;

namespace Shop.Application.Categories.Queries.GetCategories;
public record GetCategoryQuery : IRequest<List<CategoryVm>>;
