using MediatR;

namespace Shop.Application.Categories.Commands.UpdateCategory;
public sealed record UpdateCategoryCommand(
    int Id,
    string CategoryName,
    string Description) :IRequest<int>;
