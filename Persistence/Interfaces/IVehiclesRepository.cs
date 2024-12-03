namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="Vehicle"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="Vehicle"/>.
/// </summary>
public interface IVehiclesRepository : IGenericRepository<Vehicle>
{
}
