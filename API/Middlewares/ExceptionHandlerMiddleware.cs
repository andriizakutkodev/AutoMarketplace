namespace API.Middlewares;

using Microsoft.AspNetCore.Http;
using Infrastructure.Results;
using System.Net;
using System.Text.Json;
using Microsoft.Extensions.Logging;

/// <summary>
/// Middleware for handling exceptions globally in the application.
/// Captures unhandled exceptions, logs them, and returns a standardized error response.
/// </summary>
public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandlerMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger instance used for logging exceptions.</param>
    public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Middleware entry point. Processes the HTTP context and handles exceptions if they occur.
    /// </summary>
    /// <param name="context">The HTTP context of the current request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    /// <summary>
    /// Handles exceptions by setting the appropriate HTTP response status code, logging the error, 
    /// and returning a standardized JSON error response.
    /// </summary>
    /// <param name="context">The HTTP context of the current request.</param>
    /// <param name="exception">The exception that occurred.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        response.StatusCode = exception switch
        {
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            _ => (int)HttpStatusCode.InternalServerError
        };

        _logger.LogError(exception, "An unhandled exception occurred.");

        var errorResult = new Result
        {
            IsSuccess = false,
            StatusCode = (HttpStatusCode)response.StatusCode,
            Message = exception.Message,
        };

        var errorJson = JsonSerializer.Serialize(errorResult, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });

        await response.WriteAsync(errorJson);
    }
}
