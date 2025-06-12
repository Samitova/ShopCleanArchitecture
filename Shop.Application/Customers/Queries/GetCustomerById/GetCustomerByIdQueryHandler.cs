using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Customers.Queries.GetCustomerById;
public class GetCustomerByIdQueryHandler(ICustomerRepository repository, IMapper mapper)
    : IRequestHandler<GetCustomerByIdQuery, CustomerVm>
{
    private readonly ICustomerRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<CustomerVm> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _repository.GetByIdAsync(request.Id);

        return _mapper.Map<CustomerVm>(customer);
    }
}
