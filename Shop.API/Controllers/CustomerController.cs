using Microsoft.AspNetCore.Mvc;
using Shop.Application.Customers.Commands.CreateCustomer;
using Shop.Application.Customers.Commands.DeleteCustomer;
using Shop.Application.Customers.Commands.UpdateCustomer;
using Shop.Application.Customers.Queries.GetCustomerById;
using Shop.Application.Customers.Queries.GetCustomers;

namespace Shop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var customers = await Mediator.Send(new GetCustomersQuuery());

        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var order = await Mediator.Send(new GetCustomerByIdQuery(id));

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        var customer = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
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
        await Mediator.Send(new DeleteCustomerCommand(id));

        return NoContent();
    }
}
