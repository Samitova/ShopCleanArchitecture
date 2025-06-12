using FluentValidation;
using Shop.Domain.Contracts;

namespace Shop.Application.Customers.Commands.CreateCustomer;
public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    private readonly ICustomerRepository _repository;
    public CreateCustomerCommandValidator(ICustomerRepository repository)
    {
        _repository = repository;

        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("FirstName field is required");

        RuleFor(v => v.LastName)
           .NotEmpty().WithMessage("LastName field is required");
       
        RuleFor(v => v.Address)
           .NotEmpty().WithMessage("Address field is required");

        RuleFor(v => v.Email)
         .NotEmpty().WithMessage("Email field is required");

        RuleFor(v => v.Phone)
           .NotEmpty().WithMessage("Phone field is required");

        RuleFor(ws => ws)
          .MustAsync((x, cancellation) => EntityUnique(x.Email))
          .WithMessage("Email already exists.");
    }

    private async Task<bool> EntityUnique(string email)
    {
        var entities = await _repository.GetAllAsync();
        var hasEmail = entities.Where(x => x.Email.Equals(email)).Select(x => x);
        if (hasEmail.Count() > 0) return false;
        return true;
    }
}