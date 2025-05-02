using MediatR;

namespace Shop.Application.Categories.Commands.DeleteCategory;
public class DeleteCategoryCommand: IRequest<int>
{
    public int Id { get; set; }
}
