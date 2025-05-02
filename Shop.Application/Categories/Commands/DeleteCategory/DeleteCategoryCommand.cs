using MediatR;

namespace Shop.Application.Categories.Commands.DeleteCategory;
public sealed record DeleteCategoryCommand(int Id) : IRequest<int>;
