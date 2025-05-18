using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.Orders.Queries.GetOrderById;
public class GetOrderByIdQueryHandler(IOrderRepository repository, IMapper mapper)
    : IRequestHandler<GetOrderByIdQuery, OrderVm>
{
    private readonly IOrderRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderVm> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        var order = await _repository.GetByIdAsync(request.Id);

        return _mapper.Map<OrderVm>(order);
    }
}
