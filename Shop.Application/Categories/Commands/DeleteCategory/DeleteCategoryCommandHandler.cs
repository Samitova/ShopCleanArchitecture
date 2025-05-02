using MediatR;
using Shop.Domain.Contracts;

namespace Shop.Application.Categories.Commands.DeleteCategory;
public class DeleteCategoryCommandHandler(ICategoryRepository repository): IRequestHandler<DeleteCategoryCommand, int>
{
    private readonly ICategoryRepository _repository = repository;
    public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        //add check if exists
        return await _repository.DeleteAsync(request.Id);
    }
}
