namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;
using Persistence.Interfaces;

/// <summary>
/// A repository for managing <see cref="VehicleMake"/> entities.
/// Inherits common CRUD operations from <see cref="GenericRepository{T}"/>.
/// </summary>
public class VehicleMakesRepository : GenericRepository<VehicleMake>, IVehicleMakesRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleMakesRepository"/> class
    /// using the specified database context.
    /// </summary>
    /// <param name="context">The <see cref="AppDbContext"/> instance used to interact with the database.</param>
    public VehicleMakesRepository(AppDbContext context) 
        : base(context)
    {
    }
}
