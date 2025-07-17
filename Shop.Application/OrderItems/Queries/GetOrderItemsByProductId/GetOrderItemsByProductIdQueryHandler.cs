using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;

namespace Shop.Application.OrderItems.Queries.GetOrderItemsByProductId;
public class GetOrderItemsByProductIdQueryHandler(IOrderItemRepository repository, IMapper mapper)
    : IRequestHandler<GetOrderItemsByProductIdQuery, List<OrderItemVm>>
{
    private readonly IOrderItemRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<OrderItemVm>> Handle(GetOrderItemsByProductIdQuery request, CancellationToken cancellationToken)
    {
        var orderItems = await _repository.GetByProductIdAsync(request.ProductId);

        return _mapper.Map<List<OrderItemVm>>(orderItems);
    }
}
