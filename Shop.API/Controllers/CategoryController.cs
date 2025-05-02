using Microsoft.AspNetCore.Mvc;
using Shop.Application.Categories.Commands.CreateCategory;
using Shop.Application.Categories.Commands.DeleteCategory;
using Shop.Application.Categories.Commands.UpdateCategory;
using Shop.Application.Categories.Queries.GetCategories;
using Shop.Application.Categories.Queries.GetCategoryById;

namespace Shop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoryController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await Mediator.Send(new GetCategoriesQuery());

        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await Mediator.Send(new GetCategoryByIdQuery(id));

        if (category == null)
        {
            return NotFound();
        }            
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        var category = await Mediator.Send(command);
       
        return CreatedAtAction(nameof(GetById), new { id = category.Id}, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCategoryCommand command)
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
        await Mediator.Send(new DeleteCategoryCommand(id));

        return NoContent();
    }
}
