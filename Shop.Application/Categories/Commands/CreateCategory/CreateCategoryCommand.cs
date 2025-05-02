using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Categories.Commands.CreateCategory;
public sealed record CreateCategoryCommand(
    string CategoryName,
    string Description ) : IRequest<CategoryVm>;
