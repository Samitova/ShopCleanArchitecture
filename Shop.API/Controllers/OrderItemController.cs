using Microsoft.AspNetCore.Mvc;
using Shop.Application.Entities;
using Shop.Application.OrderItems.Commands.CreateOrderItem;
using Shop.Application.OrderItems.Commands.DeleteOrderItem;
using Shop.Application.OrderItems.Commands.UpdateOrderItem;
using Shop.Application.OrderItems.Queries.GetOrderItemById;
using Shop.Application.OrderItems.Queries.GetOrderItems;
using Shop.Application.OrderItems.Queries.GetOrderItemsByProductId;

namespace Shop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : ApiControllerBase
{
    [HttpGet("details")]
    [ProducesResponseType(typeof(OrderItemVm), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int orderId, int productId)
    {
        var orderItem = await Mediator.Send(new GetOrderItemByIdQuery(orderId, productId));

        if (orderItem == null)
        {
            return NotFound();
        }

        return Ok(orderItem);
    }

    [HttpGet("orderId")]
    [ProducesResponseType(typeof(List<OrderItemVm>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByOrderId(int orderId)
    {
        var orderItems = await Mediator.Send(new GetOrderItemsByOrderIdQuery(orderId));

        if (orderItems.Count == 0)
        {
            return NotFound();
        }

        return Ok(orderItems);
    }

    [HttpGet("productId")]
    [ProducesResponseType(typeof(List<OrderItemVm>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByProductId(int productId)
    {
        var orderItems = await Mediator.Send(new GetOrderItemsByProductIdQuery(productId));

        if (orderItems.Count == 0)
        {
            return NotFound();
        }

        return Ok(orderItems);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderItemCommand command)
    {
        var orderItem = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { orderId = orderItem.OrderId, productId = orderItem.ProductId }, orderItem);
    }

    [HttpPut("{orderId}/{productId}")]
    public async Task<IActionResult> Update([FromRoute] int orderId, [FromRoute] int productId, UpdateOrderItemCommand command)
    {
        if (orderId != command.OrderId || productId != command.ProductId)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{orderId}/{productId}")]
    public async Task<IActionResult> Delete([FromRoute] int orderId, [FromRoute] int productId)
    {
        await Mediator.Send(new DeleteOrderItemCommand(orderId, productId));

        return NoContent();
    }
}