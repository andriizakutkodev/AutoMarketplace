namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;
using Persistence.Interfaces;

/// <summary>
/// A repository for managing <see cref="VehicleModel"/> entities.
/// Inherits common CRUD operations from <see cref="GenericRepository{T}"/>.
/// </summary>
public class VehicleModelRepository : GenericRepository<VehicleModel>, IVehicleModelRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VehicleModelRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="AppDbContext"/> instance used to interact with the database.</param>
    public VehicleModelRepository(AppDbContext context)
        : base(context)
    {
    }
}
