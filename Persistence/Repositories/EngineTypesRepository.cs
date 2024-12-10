namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;
using Persistence.Interfaces;

/// <summary>
/// A repository for managing <see cref="EngineType"/> entities.
/// Inherits common CRUD operations from <see cref="GenericRepository{T}"/>.
/// </summary>
public class EngineTypesRepository : GenericRepository<EngineType>, IEngineTypesRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EngineTypesRepository"/> class
    /// using the specified database context.
    /// </summary>
    /// <param name="context">The <see cref="AppDbContext"/> instance used to interact with the database.</param>
    public EngineTypesRepository(AppDbContext context)
        : base(context)
    {
    }
}
