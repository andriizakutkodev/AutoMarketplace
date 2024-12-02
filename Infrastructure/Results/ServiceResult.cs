namespace Infrastructure.Results;

using System.Net;

/// <summary>
/// Represents the result of a service operation.
/// </summary>
public class ServiceResult
{
    /// <summary>
    /// Gets or sets a value indicating whether the service operation was successful.
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Gets or sets the HTTP status code associated with the service result.
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets a message providing additional details about the service result.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Creates a successful service result with a default status code of 200 (OK).
    /// </summary>
    /// <returns>A <see cref="ServiceResult"/> indicating a successful operation.</returns>
    public static ServiceResult Success() => new ()
    {
        IsSuccess = true,
        StatusCode = (int)HttpStatusCode.OK,
    };

    /// <summary>
    /// Creates a failed service result with the specified message and status code.
    /// </summary>
    /// <param name="message">The error message describing the failure.</param>
    /// <param name="statusCode">The HTTP status code representing the failure.</param>
    /// <returns>A <see cref="ServiceResult"/> indicating a failed operation.</returns>
    public static ServiceResult Failure(string message, int statusCode) => new ()
    {
        IsSuccess = false,
        StatusCode = statusCode,
        Message = message,
    };
}
