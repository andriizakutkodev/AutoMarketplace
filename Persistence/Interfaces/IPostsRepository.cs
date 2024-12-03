namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="Post"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="Post"/>.
/// </summary>
public interface IPostsRepository : IGenericRepository<Post>
{
}
