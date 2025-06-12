using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.Customers.Commands.UpdateCustomer;
public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    private readonly ICustomerRepository _repository;
    public UpdateCustomerCommandValidator(ICustomerRepository repository)
    {
        _repository = repository;

        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("FirstName field is required")
            .MaximumLength(15).WithMessage("Sku must not exceed 50 characters");

        RuleFor(v => v.LastName)
            .NotEmpty().WithMessage("LastName field is required")
            .MaximumLength(200).WithMessage("Name must not exceed 50 characters");

        RuleFor(v => v.Address)
            .NotEmpty().WithMessage("Address field is required");

        RuleFor(v => v.Phone)
            .NotEmpty().WithMessage("Phone field is required");

        RuleFor(ws => ws)
            .MustAsync((x, cancellation) => EntityExists(x.Id))
            .WithMessage("Customer was not found.");

        RuleFor(ws => ws)
           .MustAsync((x, cancellation) => EntityUnique(x.Email))
           .WithMessage("Email already exists.");
    }

    private async Task<bool> EntityExists(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return false;
        return true;
    }

    private async Task<bool> EntityUnique(string email)
    {
        var entities = await _repository.GetAllAsync();
        var hasEmail = entities.Where(x => x.Email.Equals(email)).Select(x=>x);
        if (hasEmail.Count() > 0) return false;
        return true;
    }
}
