using Microsoft.AspNetCore.Mvc;
using Shop.Application.Entities;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Application.Products.Queries.GetProductById;
using Shop.Application.Products.Queries.GetProducts;

namespace Shop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await Mediator.Send(new GetProductsQuery());

        return Ok(products);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProductVm), StatusCodes.Status200OK)]
    public async Task<ActionResult<ProductVm>> GetById(int id)
    {
        var product = await Mediator.Send(new GetProductByIdQuery(id));

        if (product == null) 
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommand command)
    { 
        var product = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = product.Id}, product);
    }

    [HttpPut("{id}")]  
    public async Task<IActionResult> Update(int id, UpdateProductCommand command)
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
        await Mediator.Send(new DeleteProductCommand(id));

        return NoContent();
    }
}