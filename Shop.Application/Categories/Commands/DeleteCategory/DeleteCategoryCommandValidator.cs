using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.Categories.Commands.DeleteCategory;
public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _repository;
    public DeleteCategoryCommandValidator(ICategoryRepository repository)
    {
        _repository = repository;

        RuleFor(ws => ws).MustAsync((x, cancellation) => EntityExists(x.Id)).WithMessage("Category was not found.");
    }

    private async Task<bool> EntityExists(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;       
        return true;
    }
}