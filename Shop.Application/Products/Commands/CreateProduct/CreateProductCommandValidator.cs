using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.Products.Commands.CreateProduct;
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly ICategoryRepository _repository;
    public CreateProductCommandValidator(ICategoryRepository repository)
    {
        _repository = repository;
        RuleFor(v => v.Sku)
            .NotEmpty().WithMessage("Sku field is required")
            .MaximumLength(15).WithMessage("Sku must not exceed 15 characters");

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name field is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description field is required");

        RuleFor(v => v.Price)            
            .GreaterThan(0).WithMessage("Price should be greater than 0");

        RuleFor(v => v.QuantityInStock)
            .GreaterThan(-1).WithMessage("Price should be greater than or equal 0");

        RuleFor(ws => ws)
            .MustAsync((x, cancellation) => EntityExists(x.CategoryId))
            .WithMessage("Category for the product was not found.");
    }

    private async Task<bool> EntityExists(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;
        return true;
    }
}
