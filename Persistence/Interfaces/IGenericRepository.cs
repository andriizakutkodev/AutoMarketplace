namespace Persistence.Interfaces;

using System.Linq.Expressions;

/// <summary>
/// A generic repository interface for performing CRUD operations on entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of entity the repository will manage. Must be a reference type.</typeparam>
public interface IGenericRepository<T>
    where T : class
{
    /// <summary>
    /// Retrieves a collection of entities from the database, optionally filtered by a predicate, and with optional pagination.
    /// </summary>
    /// <param name="predicate">An optional filter expression to apply to the entities. If null, no filter is applied.</param>
    /// <param name="skip">An optional number of records to skip. If null, no records are skipped.</param>
    /// <param name="take">An optional number of records to take. If null, all matching records are returned.</param>
    /// <returns>
    /// A task representing the asynchronous operation, containing a collection of entities that match the specified criteria.
    /// </returns>
    Task<ICollection<T>> GetAll(Expression<Func<T, bool>>? predicate = default, int? skip = default, int? take = default);

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

    /// <summary>
    /// Checks if a record with the specified ID exists in the database.
    /// </summary>
    /// <param name="id">The GUID identifier of the record to check.</param>
    /// <returns>A task representing the asynchronous operation, with a boolean result indicating whether the record exists.</returns>
    Task<(bool, T?)> IsRecordExist(Guid id);
}