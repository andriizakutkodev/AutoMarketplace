namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="User"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="User"/>.
/// </summary>
public interface IUsersRepository : IGenericRepository<User>
{
}
