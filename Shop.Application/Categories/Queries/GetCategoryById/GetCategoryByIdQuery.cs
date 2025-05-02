using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Categories.Queries.GetCategoryById;
public sealed record GetCategoryByIdQuery(int Id) : IRequest<CategoryVm>;
