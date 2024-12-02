namespace API.Controllers;

using System.Net;
using Infrastructure.Results;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Base controller providing common result handling for API responses.
/// </summary>
[ApiController]
public class BaseAPIController : ControllerBase
{
    /// <summary>
    /// Converts a <see cref="ServiceResult"/> into an appropriate IActionResult.
    /// </summary>
    /// <param name="result">The service result to handle.</param>
    /// <returns>An <see cref="IActionResult"/> corresponding to the service result.</returns>
    protected IActionResult HandleResult(ServiceResult result)
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
    /// Converts a <see cref="ServiceResult{T}"/> into an appropriate IActionResult.
    /// </summary>
    /// <typeparam name="T">The type of the data in the service result.</typeparam>
    /// <param name="result">The service result to handle.</param>
    /// <returns>An <see cref="IActionResult"/> corresponding to the service result.</returns>
    protected IActionResult HandleResult<T>(ServiceResult<T> result)
    {
        return result.StatusCode switch
        {
            HttpStatusCode.OK => new OkObjectResult(result),
            HttpStatusCode.NotFound => new NotFoundObjectResult(result),
            HttpStatusCode.BadRequest => new BadRequestObjectResult(result),
            _ => throw new NotImplementedException()
        };
    }
}
