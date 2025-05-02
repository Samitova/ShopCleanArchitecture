using FluentValidation;

namespace Shop.Application.Categories.Commands.CreateCategory;
public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(v => v.CategoryName)
            .NotEmpty().WithMessage("Name field is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Name field is required");
    }
}
