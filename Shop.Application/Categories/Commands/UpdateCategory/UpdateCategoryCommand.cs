using MediatR;
using Shop.Domain.Entities;

namespace Shop.Application.Categories.Commands.UpdateCategory;
public class UpdateCategoryCommand:IRequest<int>
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; }
}
