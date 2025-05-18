using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.Products.Commands.DeleteProduct;
public class DeleteProductCommandValidator: AbstractValidator<DeleteProductCommand>
{
    private readonly IProductRepository _repository;
    public DeleteProductCommandValidator(IProductRepository repository)
    {
        _repository = repository;

        RuleFor(ws => ws)
            .MustAsync((x, cancellation) => EntityExists(x.Id))
            .WithMessage("Product was not found.");
    }

    private async Task<bool> EntityExists(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;
        return true;
    }
}
