using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Shop.API.Infrastructure;

public class GlobalExceptionHandler: IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not ValidationException)
        {
            _logger.LogError(exception, $"Exception occured: {exception.Message}");

            var problemDetailes = new ProblemDetails
            {
                Title = "Server Error",
                Status = StatusCodes.Status500InternalServerError
            };           

            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(problemDetailes, cancellationToken);

            return true;
        }

        return false;
    }
}
