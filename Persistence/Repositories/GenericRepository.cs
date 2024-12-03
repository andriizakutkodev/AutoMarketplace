namespace Persistence.Repositories;

using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

/// <summary>
/// A generic repository implementation for performing common database operations.
/// </summary>
/// <typeparam name="T">The type of entity this repository manages. Must be a reference type.</typeparam>
public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
    /// </summary>
    /// <param name="context">The database context to be used by the repository.</param>
    public GenericRepository(AppDbContext context) => _context = context;

    /// <summary>
    /// Asynchronously creates a new entity in the database.
    /// </summary>
    /// <param name="entity">The entity to create.</param>
    /// <returns>True if the entity was successfully created; otherwise, false.</returns>
    public async Task<bool> Create(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Asynchronously deletes an existing entity from the database.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    /// <returns>True if the entity was successfully deleted; otherwise, false.</returns>
    public async Task<bool> Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    /// <summary>
    /// Asynchronously retrieves all entities of type <typeparamref name="T"/> from the database.
    /// </summary>
    /// <returns>A collection of all entities of type <typeparamref name="T"/>.</returns>
    public async Task<ICollection<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    /// <summary>
    /// Asynchronously retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>The entity if found; otherwise, null.</returns>
    public async Task<T?> GetById(Guid id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    /// <summary>
    /// Asynchronously updates an existing entity in the database.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>True if the entity was successfully updated; otherwise, false.</returns>
    public async Task<bool> Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}