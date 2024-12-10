namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="EngineType"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="EngineType"/>.
/// </summary>
public interface IEngineTypesRepository : IGenericRepository<EngineType>
{
}
