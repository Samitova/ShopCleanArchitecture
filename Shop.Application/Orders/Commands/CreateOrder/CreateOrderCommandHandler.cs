using AutoMapper;
using MediatR;
using Shop.Application.Entities;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Orders.Commands.CreateOrder;
public class CreateOrderCommandHandler(IOrderRepository repository, IMapper mapper)
    : IRequestHandler<CreateOrderCommand, OrderVm>
{
    private readonly IOrderRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<OrderVm> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            CreatedAt = DateTime.UtcNow,
            CustomerId = request.CustomerId,
            OrderStatus = OrderStatus.Created,
            ShippedAt = request.ShippedAt,  
            ShippingAddress = request.ShippingAddress,
            OrderItems =_mapper.Map<ICollection<OrderItem>>(request.OrderItems)
        };

        await _repository.CreateAsync(order);
        return _mapper.Map<OrderVm>(order);
    }
}