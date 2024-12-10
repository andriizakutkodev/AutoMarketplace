namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;
using Persistence.Interfaces;

/// <summary>
/// A repository for managing <see cref="FuelType"/> entities.
/// Inherits common CRUD operations from <see cref="GenericRepository{T}"/>.
/// </summary>
public class FuelTypesRepository : GenericRepository<FuelType>, IFuelTypesRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="FuelTypesRepository"/> class
    /// using the specified database context.
    /// </summary>
    /// <param name="context">The <see cref="AppDbContext"/> instance used to interact with the database.</param>
    public FuelTypesRepository(AppDbContext context)
        : base(context)
    {
    }
}
