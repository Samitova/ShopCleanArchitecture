using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Categories.Queries.GetCategories;
public record GetCategoriesQuery : IRequest<List<CategoryVm>>;
