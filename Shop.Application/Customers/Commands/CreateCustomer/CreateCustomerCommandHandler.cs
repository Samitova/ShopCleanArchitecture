using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Customers.Commands.CreateCustomer;
public class CreateCustomerCommandHandler(ICustomerRepository repository, IMapper mapper)
    : IRequestHandler<CreateCustomerCommand, CustomerVm>
{
    private readonly ICustomerRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<CustomerVm> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            Address = request.Address,
            Email = request.Email            
        };

        await _repository.CreateAsync(customer);
        return _mapper.Map<CustomerVm>(customer);
    }
}
