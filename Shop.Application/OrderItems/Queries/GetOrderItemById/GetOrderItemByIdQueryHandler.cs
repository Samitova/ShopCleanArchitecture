using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.OrderItems.Queries.GetOrderItemById;
public class GetOrderItemByIdQueryHandler(IOrderItemRepository repository, IMapper mapper)
    : IRequestHandler<GetOrderItemByIdQuery, OrderItemVm>
{
    private readonly IOrderItemRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderItemVm> Handle(GetOrderItemByIdQuery request, CancellationToken cancellationToken)
    {
        var orderItem = await _repository.GetByIdAsync(request.OrderId, request.ProductId);

        return _mapper.Map<OrderItemVm>(orderItem);
    }
}
