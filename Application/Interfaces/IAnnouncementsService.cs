namespace Application.Interfaces;

using Application.DTOs;
using Infrastructure.Results;

/// <summary>
/// Provides an abstraction for announcement-related business logic.
/// Defines methods for creating, retrieving, updating, and deleting posts.
/// </summary>
public interface IAnnouncementsService
{
    Task<Result<ICollection<AnnouncementDto>>> GetAll();

    Task<Result<AnnouncementDto>> GetById(Guid id);

    Task<Result> Create(CreateAnnouncementDto createAnnouncementDto);
}
