namespace API.Extensions;

using System.Security.Claims;

/// <summary>
/// Provides extension methods for the <see cref="HttpContext"/> to simplify user-related operations.
/// </summary>
public static class HttpContextExtensions
{
    /// <summary>
    /// Retrieves the unique identifier (User ID) of the currently authenticated user from the claims.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> instance representing the current HTTP request.</param>
    /// <returns>
    /// A <see cref="Guid"/> representing the unique identifier of the logged-in user.
    /// </returns>
    /// <exception cref="UnauthorizedAccessException">
    /// Thrown when the user is not authenticated.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the User ID claim is missing or invalid.
    /// </exception>
    public static Guid GetLoggedUserId(this HttpContext context)
    {
        if (context?.User?.Identity?.IsAuthenticated != true)
        {
            throw new UnauthorizedAccessException();
        }

        var userIdClaim = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        if (userIdClaim == null || !Guid.TryParse(userIdClaim.Value, out var userId))
        {
            throw new InvalidOperationException("User ID claim is missing or invalid.");
        }

        return userId;
    }
}
