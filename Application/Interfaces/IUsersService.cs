namespace Application.Interfaces;

using Domain.Entities;
using Infrastructure.Results;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Defines the contract for a service responsible for user-related operations such as retrieving and creating users.
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the user if found, or an error result if no user exists with the given email.
    /// </returns>
    Task<Result<User>> GetByEmail(string email);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="user">The user object containing the details of the new user.</param>
    /// <returns>
    /// A <see cref="Result"/> indicating the success or failure of the user creation process.
    /// </returns>
    Task<Result> Create(User user);
}
