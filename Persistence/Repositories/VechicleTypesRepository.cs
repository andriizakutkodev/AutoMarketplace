namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;
using Persistence.Interfaces;

/// <summary>
/// A repository for managing <see cref="VehicleType"/> entities.
/// Inherits common CRUD operations from <see cref="GenericRepository{T}"/>.
/// </summary>
public class VechicleTypesRepository : GenericRepository<VehicleType>, IVehicleTypesRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VechicleTypesRepository"/> class
    /// using the specified database context.
    /// </summary>
    /// <param name="context">The <see cref="AppDbContext"/> instance used to interact with the database.</param>
    public VechicleTypesRepository(AppDbContext context) : base(context)
    {
    }
}
