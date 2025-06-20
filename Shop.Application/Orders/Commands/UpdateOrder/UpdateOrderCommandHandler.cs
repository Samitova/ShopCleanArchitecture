﻿using AutoMapper;
using MediatR;
using Shop.Domain.Contracts;
using Shop.Domain.Entities;

namespace Shop.Application.Orders.Commands.UpdateOrder;
public class UpdateOrderCommandHandler(IOrderRepository repository, IMapper mapper) 
    : IRequestHandler<UpdateOrderCommand, int>
{
    private readonly IOrderRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<int> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = request.Id,
            CustomerId = request.CustomerId,
            ShippedAt = request.ShippedAt,
            ShippingAddress = request.ShippingAddress,
            OrderStatus = request.OrderStatus
        };

        var result = await _repository.UpdateAsync(request.Id, order);
        return result;
    }
}
