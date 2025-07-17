using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Orders.Queries.GetOrders;
public class GetOrdersQuueryHandler(IOrderRepository repository, IMapper mapper)
    : IRequestHandler<GetOrdersQuuery, List<OrderVm>>
{
    private readonly IOrderRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<OrderVm>> Handle(GetOrdersQuuery request, CancellationToken cancellationToken)
    {
        var orders = await _repository.GetAllAsync();

        return _mapper.Map<List<OrderVm>>(orders);
    }
}
