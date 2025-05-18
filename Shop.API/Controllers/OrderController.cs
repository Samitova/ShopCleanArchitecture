using Microsoft.AspNetCore.Mvc;
using Shop.Application.Orders.Commands.CreateOrder;
using Shop.Application.Orders.Commands.DeleteOrder;
using Shop.Application.Orders.Commands.UpdateOrder;
using Shop.Application.Orders.Queries.GetOrderById;
using Shop.Application.Orders.Queries.GetOrders;

namespace Shop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController: ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await Mediator.Send(new GetOrdersQuuery());

        return Ok(orders);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await Mediator.Send(new GetOrderByIdQuery(id));

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand command)
    {
        var order = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateOrderCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteOrderCommand(id));

        return NoContent();
    }
}
