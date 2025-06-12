using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Customers.Queries.GetCustomers;
public class GetCustomersQuueryHandler(ICustomerRepository repository, IMapper mapper)
    : IRequestHandler<GetCustomersQuuery, List<CustomerVm>>
{
    private readonly ICustomerRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CustomerVm>> Handle(GetCustomersQuuery request, CancellationToken cancellationToken)
    {
        var customers = await _repository.GetAllAsync();

        return _mapper.Map<List<CustomerVm>>(customers);
    }
}