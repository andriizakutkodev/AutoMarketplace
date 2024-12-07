namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="User"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="User"/>.
/// </summary>
public interface IUsersRepository : IGenericRepository<User>
{
    /// <summary>
    /// Checks if a given email address is already associated with an existing user in the repository.
    /// </summary>
    /// <param name="email">The email address to check for availability.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a boolean result indicating whether the email is taken (<c>true</c>) or not (<c>false</c>).
    /// </returns>
    Task<bool> IsUserWithEmailExists(string email);

    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a <see cref="User"/> object containing the user's details if found, or <c>null</c> if no user exists with the given email.
    /// </returns>
    Task<User> GetByEmail(string email);
}
