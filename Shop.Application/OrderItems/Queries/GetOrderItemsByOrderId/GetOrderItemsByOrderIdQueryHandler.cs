using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.OrderItems.Queries.GetOrderItems;
public class GetOrderItemsByOrderIdQueryHandler(IOrderItemRepository repository, IMapper mapper)
    : IRequestHandler<GetOrderItemsByOrderIdQuery, List<OrderItemVm>>
{
    private readonly IOrderItemRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<OrderItemVm>> Handle(GetOrderItemsByOrderIdQuery request, CancellationToken cancellationToken)
    {
        var orderItems = await _repository.GetByOrderIdAsync(request.OrderId);

        return _mapper.Map<List<OrderItemVm>>(orderItems);
    }
}
