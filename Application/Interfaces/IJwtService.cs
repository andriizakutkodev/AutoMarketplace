namespace Application.Interfaces;

using Domain.Entities;
using Infrastructure.Results;

/// <summary>
/// Defines the contract for a service responsible for generating JSON Web Tokens (JWT) for users.
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Generates a JSON Web Token (JWT) for a user.
    /// </summary>
    /// <param name="user">The user for whom the JWT will be generated.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the generated JWT string if successful,
    /// or an error result if token generation fails.
    /// </returns>
    Result<string> GenerateToken(User user);
}
