using FluentValidation;

namespace Shop.Application.Categories.Commands.UpdateCategory;
public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(v => v.CategoryName)
            .NotEmpty().WithMessage("Name field is required")
            .MaximumLength(200).WithMessage("Name must not exceed 200 characters");

        RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description field is required");
    }
}
