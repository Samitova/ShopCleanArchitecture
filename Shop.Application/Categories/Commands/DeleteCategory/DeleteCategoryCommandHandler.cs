using MediatR;
using Shop.Domain.Contracts;

namespace Shop.Application.Categories.Commands.DeleteCategory;
public class DeleteCategoryCommandHandler(ICategoryRepository repository) : IRequestHandler<DeleteCategoryCommand, int>
{
    public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        //add check if exists
        return await repository.DeleteAsync(request.Id);
    }
}
