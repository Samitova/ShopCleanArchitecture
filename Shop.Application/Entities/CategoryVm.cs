using Shop.Domain.Entities;

namespace Shop.Application.Entities;
public class CategoryVm
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<Product> Products { get; set; }
}
