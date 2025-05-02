using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Entities;

namespace Shop.Application.Categories.Commands.CreateCategory;
public class CreateCategoryCommand: IRequest<CategoryVm>
{
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; }
}
