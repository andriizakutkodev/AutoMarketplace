namespace Infrastructure.Middlewares;

using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Middleware for checking the expiration of JWT tokens in incoming HTTP requests.
/// </summary>
public class TokenExpirationMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="TokenExpirationMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next <see cref="RequestDelegate"/> in the middleware pipeline.</param>
    public TokenExpirationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Invokes the middleware to check for token expiration.
    /// </summary>
    /// <param name="httpContext">The HTTP context for the current request.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext httpContext)
    {
        var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
        {
            if (IsTokenExpired(token))
            {
                throw new UnauthorizedAccessException("Token has expired.");
            }
        }

        await _next(httpContext);
    }

    /// <summary>
    /// Determines whether the given JWT token has expired.
    /// </summary>
    /// <param name="token">The JWT token to check for expiration.</param>
    /// <returns><c>true</c> if the token is expired; otherwise, <c>false</c>.</returns>
    private bool IsTokenExpired(string token)
    {
        try
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);

            return jwtToken.ValidTo < DateTime.UtcNow;
        }
        catch
        {
            return true;
        }
    }
}
