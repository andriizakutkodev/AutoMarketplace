namespace API.Extensions;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

/// <summary>
/// Provides extension methods for the <see cref="HttpContext"/> class to simplify common operations.
/// </summary>
public static class HttpContextExtensions
{
    /// <summary>
    /// Retrieves the User ID from the session's JWT claims in the <see cref="HttpContext"/>.
    /// </summary>
    /// <param name="context">The <see cref="HttpContext"/> instance to retrieve the User ID from.</param>
    /// <returns>
    /// The User ID as a <see cref="string"/> if the claim exists; otherwise, <c>null</c>.
    /// </returns>
    public static string? GetSessionUserId(this HttpContext context)
    {
        if (context?.User?.Identity is ClaimsIdentity identity)
        {
            var userIdClaim = identity.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
            return userIdClaim?.Value;
        }

        return null;
    }
}
