using MediatR;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Categories.Commands.UpdateCategory;
public class UpdateCategoryCommandHandler(ICategoryRepository repository): IRequestHandler<UpdateCategoryCommand, int>
{
    private readonly ICategoryRepository _repository = repository;

    public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = request.Id,
            Name = request.CategoryName,
            Description = request.Description
        };

        var result  = await _repository.UpdateAsync(request.Id, category);
        return result;
    }
}
