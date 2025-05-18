using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.Products.Commands.UpdateProduct;
public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommand>
{
    private readonly ICategoryRepository _repository;
    public UpdateProductCommandValidator(ICategoryRepository repository)
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
            .NotEmpty().WithMessage("Price field is required")
            .GreaterThan(0).WithMessage("Price should be greater than 0");

        RuleFor(v => v.QuantityInStock)
            .NotEmpty().WithMessage("QuantityInStock field is required")
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
