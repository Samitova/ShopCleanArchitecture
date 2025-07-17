using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.OrderItems.Commands.CreateOrderItem;
public class CreateOrderItemCommandHandler(IOrderItemRepository repository, IMapper mapper)
    : IRequestHandler<CreateOrderItemCommand, OrderItemVm>
{
    private readonly IOrderItemRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderItemVm> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
    {
        var orderItem = new OrderItem
        {
            OrderId = request.OrderId,
            ProductId = request.ProductId,
            UnitPrice = request.UnitPrice,
            OrderedQuantity = request.OrderedQuantity
        };

        await _repository.CreateAsync(orderItem);
        return _mapper.Map<OrderItemVm>(orderItem);
    }
}