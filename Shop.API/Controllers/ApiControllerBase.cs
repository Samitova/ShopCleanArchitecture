using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Common.Validation;

namespace Shop.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender _mediator;
   
    protected ISender Mediator => _mediator 
        ?? HttpContext.RequestServices.GetRequiredService<ISender>();

    protected IActionResult HandleFailure(Result result) =>
        result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),
            IValidationResult validationResult => 
                BadRequest(
                    CreateProblemDetailes(
                        "Validation Error",
                        StatusCodes.Status400BadRequest,
                        result.Error,
                        validationResult.Errors)),
            _ => 
                BadRequest(
                    CreateProblemDetailes(
                        "Bad Request",
                        StatusCodes.Status400BadRequest,
                    result.Error)),
        };

    private static ProblemDetails CreateProblemDetailes(
        string title,
        int status,
        Error error,
        Error?[] errors = null) =>
        new()
        { 
            Title = title,
            Status = status,
            Type = error.Code,
            Detail =error.Message,
            Extensions = new Dictionary<string, object?> { { nameof(errors), errors } }
        };
}
