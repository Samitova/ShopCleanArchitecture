using AutoMapper;
using MediatR;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Customers.Commands.UpdateCustomer;
public class UpdateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
    : IRequestHandler<UpdateCustomerCommand, int>
{
    private readonly ICustomerRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            Address = request.Address,
            Email = request.Email
        };

        var result = await _repository.UpdateAsync(request.Id, customer);
        return result;
    }
}
