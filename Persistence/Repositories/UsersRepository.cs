namespace Persistence.Repositories;

using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

/// <summary>
/// A repository for managing <see cref="User"/> entities.
/// Inherits common CRUD operations from <see cref="GenericRepository{T}"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UsersRepository"/> class with the specified database context.
/// </remarks>
/// <param name="context">The database context used to interact with the <see cref="User"/> table.</param>
public class UsersRepository : GenericRepository<User>, IUsersRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UsersRepository"/> class
    /// using the specified database context.
    /// </summary>
    /// <param name="context">The <see cref="AppDbContext"/> instance used to interact with the database.</param>
    public UsersRepository(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a <see cref="User"/> object containing the user's details if found, or throws an exception if no user is found.
    /// </returns>
    /// <exception cref="InvalidOperationException">
    /// Thrown when no user is found with the given email.
    /// </exception>
    public async Task<User> GetByEmail(string email)
    {
        return await _context.Users.FirstAsync(u => u.Email == email);
    }

    /// <summary>
    /// Checks if a given email address is already associated with an existing user in the repository.
    /// </summary>
    /// <param name="email">The email address to check for availability.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a boolean result indicating whether the email is taken (<c>true</c>) or not (<c>false</c>).
    /// </returns>
    public async Task<bool> IsUserWithEmailExists(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}
