namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;

/// <summary>
/// A repository for managing <see cref="User"/> entities. 
/// Inherits common CRUD operations from <see cref="GenericRepository{T}"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UsersRepository"/> class with the specified database context.
/// </remarks>
/// <param name="context">The database context used to interact with the <see cref="User"/> table.</param>
public class UsersRepository(AppDbContext context) : GenericRepository<User>(context)
{
}
