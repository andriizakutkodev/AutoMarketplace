namespace Persistence.Interfaces;

using Domain.Entities;

/// <summary>
/// Represents a repository interface for managing <see cref="Announcement"/> entities.
/// Extends the generic repository interface with methods specific to <see cref="Announcement"/>.
/// </summary>
public interface IAnnouncementsRepository : IGenericRepository<Announcement>
{
}
