namespace Persistence.Repositories;

using Domain.Entities;
using Infrastructure.Data;
using Persistence.Interfaces;

/// <summary>
/// A repository for managing <see cref="Image"/> entities.
/// Inherits common CRUD operations from <see cref="GenericRepository{T}"/>.
/// </summary>
public class ImageRepository : GenericRepository<Image>, IImageRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageRepository"/> class.
    /// </summary>
    /// <param name="context">The <see cref="AppDbContext"/> instance used to interact with the database.</param>
    public ImageRepository(AppDbContext context)
        : base(context)
    {
    }
}
