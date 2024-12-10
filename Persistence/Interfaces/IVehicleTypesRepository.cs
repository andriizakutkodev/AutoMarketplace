namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="VehicleType"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="VehicleType"/>.
/// </summary>
public interface IVehicleTypesRepository : IGenericRepository<VehicleType>
{
}
