using MediatR;
using Shop.Application.Entities;

namespace Shop.Application.Categories.Queries.GetCategoryById;
public class GetCategoryByIdQuery: IRequest<CategoryVm>
{
    public int Id { get; set; }
}
