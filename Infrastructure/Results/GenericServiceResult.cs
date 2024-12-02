namespace Infrastructure.Results;

using System.Net;

/// <summary>
/// Represents a generic result for a service operation.
/// </summary>
/// <typeparam name="T">The type of the data returned by the service.</typeparam>
public class ServiceResult<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the service operation was successful.
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Gets or sets the data returned by the service operation.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Gets or sets the HTTP status code associated with the service result.
    /// </summary>
    public HttpStatusCode StatusCode { get; set; }

    /// <summary>
    /// Gets or sets a message providing additional details about the service result.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Creates a successful service result with the specified data.
    /// </summary>
    /// <param name="data">The data to include in the service result.</param>
    /// <returns>A <see cref="ServiceResult{T}"/> indicating a successful operation.</returns>
    public static ServiceResult<T> Success(T data) => new ()
    {
        IsSuccess = true,
        Data = data,
        StatusCode = HttpStatusCode.OK,
    };

    /// <summary>
    /// Creates a failed service result with the specified message and status code.
    /// </summary>
    /// <param name="message">The error message describing the failure.</param>
    /// <param name="statusCode">The HTTP status code representing the failure.</param>
    /// <returns>A <see cref="ServiceResult{T}"/> indicating a failed operation.</returns>
    public static ServiceResult<T> Failure(string message, HttpStatusCode statusCode) => new ()
    {
        IsSuccess = false,
        Message = message,
        StatusCode = statusCode,
    };
}
