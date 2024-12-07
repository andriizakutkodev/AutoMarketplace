namespace API.Controllers;

using System.Net;

using FluentValidation.Results;

using Infrastructure.Results;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Base controller providing common result handling for API responses.
/// </summary>
[ApiController]
public class BaseAPIController : ControllerBase
{
    /// <summary>
    /// Converts a <see cref="Result"/> into an appropriate IActionResult.
    /// </summary>
    /// <param name="result">The service result to handle.</param>
    /// <returns>An <see cref="IActionResult"/> corresponding to the service result.</returns>
    protected IActionResult HandleResult(Result result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.OK => new OkObjectResult(result),
            HttpStatusCode.NotFound => new NotFoundObjectResult(result),
            HttpStatusCode.BadRequest => new BadRequestObjectResult(result),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// Converts a <see cref="Result{T}"/> into an appropriate IActionResult.
    /// </summary>
    /// <typeparam name="T">The type of the data in the service result.</typeparam>
    /// <param name="result">The service result to handle.</param>
    /// <returns>An <see cref="IActionResult"/> corresponding to the service result.</returns>
    protected IActionResult HandleResult<T>(Result<T> result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.OK => new OkObjectResult(result),
            HttpStatusCode.NotFound => new NotFoundObjectResult(result),
            HttpStatusCode.BadRequest => new BadRequestObjectResult(result),
            _ => throw new NotImplementedException()
        };
    }

    /// <summary>
    /// Creates a result object for invalid models.
    /// </summary>
    /// <param name="errors">The list of validation failures.</param>
    /// <returns>A <see cref="Result"/> object indicating a bad request with the validation errors.</returns>
    /// <remarks>
    /// This method formats the validation errors into a result object that can be returned as part of the response.
    /// </remarks>
    protected Result CreateModelNotValidResult(List<ValidationFailure> errors)
    {
        return new() { IsSuccess = false, StatusCode = HttpStatusCode.BadRequest, Message = errors.ToString()! };
    }
}
