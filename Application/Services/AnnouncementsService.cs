namespace Application.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Infrastructure.Results;

using Persistence.Interfaces;

/// <summary>
/// Implements the <see cref="IAnnouncementsService"/> interface to handle business logic for managing posts.
/// Provides functionality for creating, retrieving, updating, and deleting posts by interacting with the repository.
/// </summary>
public class AnnouncementsService(IAnnouncementsRepository repository) : IAnnouncementsService
{
    public async Task<Result<ICollection<AnnouncementDto>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Result<AnnouncementDto>> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Result> Create(CreateAnnouncementDto createAnnouncementDto)
    {
        throw new NotImplementedException();
    }
}
