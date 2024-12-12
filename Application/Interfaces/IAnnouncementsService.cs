namespace Application.Interfaces;

using Application.DTOs;
using Infrastructure.Results;

/// <summary>
/// Defines a service interface for managing announcements.
/// </summary>
public interface IAnnouncementsService
{
    /// <summary>
    /// Retrieves all announcements.
    /// </summary>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a result containing a collection of <see cref="AnnouncementDto"/> objects.
    /// </returns>
    Task<Result<ICollection<AnnouncementDto>>> GetAll();

    /// <summary>
    /// Retrieves a specific announcement by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the announcement to retrieve.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a result containing the <see cref="AnnouncementDto"/> if found,
    /// or an error result if not found.
    /// </returns>
    Task<Result<AnnouncementDto>> GetById(Guid id);

    /// <summary>
    /// Creates a new announcement using the provided data.
    /// </summary>
    /// <param name="createAnnouncementDto">The data transfer object containing the details of the announcement to create.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a result indicating whether the operation was successful or if an error occurred.
    /// </returns>
    Task<Result> Create(CreateAnnouncementDto createAnnouncementDto);

    /// <summary>
    /// Updates an existing announcement using the provided data.
    /// </summary>
    /// <param name="updateAnnouncementDto">The data transfer object containing the updated details of the announcement.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a result indicating whether the update was successful or if an error occurred.
    /// </returns>
    Task<Result> Update(UpdateAnnouncementDto updateAnnouncementDto);

    /// <summary>
    /// Deletes a specific announcement by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the announcement to delete.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a result indicating whether the deletion was successful or if an error occurred.
    /// </returns>
    Task<Result> Delete(Guid id);
}
