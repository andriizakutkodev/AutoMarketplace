namespace Persistence.Interfaces;

/// <summary>
/// A generic repository interface for performing CRUD operations on entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of entity the repository will manage. Must be a reference type.</typeparam>
public interface IGenericRepository<T>
    where T : class
{
    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/> from the database.
    /// </summary>
    /// <returns>A collection of all entities of type <typeparamref name="T"/>.</returns>
    Task<ICollection<T>> GetAll();

    /// <summary>
    /// Retrieves a specific entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    Task<T?> GetById(Guid id);

    /// <summary>
    /// Creates a new entity of type <typeparamref name="T"/> in the database.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <returns>True if the entity was successfully created; otherwise, false.</returns>
    Task<bool> Create(T entity);

    /// <summary>
    /// Updates an existing entity of type <typeparamref name="T"/> in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>True if the entity was successfully updated; otherwise, false.</returns>
    Task<bool> Update(T entity);

    /// <summary>
    /// Deletes an existing entity of type <typeparamref name="T"/> from the database.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>True if the entity was successfully deleted; otherwise, false.</returns>
    Task<bool> Delete(T entity);
}