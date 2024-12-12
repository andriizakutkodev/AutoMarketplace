namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;
using Persistence.Interfaces;

/// <summary>
/// Implements the <see cref="IAnnouncementsRepository"/> interface to manage posts in the data store.
/// Provides functionality for creating, retrieving, updating, and deleting posts.
/// </summary>
public class AnnouncementsRepository(AppDbContext context) : GenericRepository<Announcement>(context), IAnnouncementsRepository
{
}
