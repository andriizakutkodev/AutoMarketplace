namespace Application.Services;

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Results;
using Persistence.Interfaces;

/// <summary>
/// Implements the <see cref="IAnnouncementsService"/> interface to handle business logic for managing posts.
/// Provides functionality for creating, retrieving, updating, and deleting posts by interacting with the repository.
/// </summary>
public class AnnouncementsService(
    IAnnouncementsRepository repository,
    IVehicleModelsRepository vehicleModelsRepository,
    IUsersRepository usersRepository,
    IMapper mapper) : IAnnouncementsService
{
    /// <summary>
    /// Retrieves all announcements and maps them to a collection of <see cref="AnnouncementDto"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation,
    /// with a result containing a collection of <see cref="AnnouncementDto"/> objects
    /// if the retrieval is successful.
    /// </returns>
    public async Task<Result<ICollection<AnnouncementDto>>> GetAll()
    {
        var announcements = await repository.GetAll();

        var announcementDtos = announcements.Select(mapper.Map<AnnouncementDto>).ToList();

        return Result<ICollection<AnnouncementDto>>.Success(announcementDtos);
    }

    /// <summary>
    /// Retrieves an announcement by its unique identifier and maps it to an <see cref="AnnouncementDto"/>.
    /// </summary>
    /// <param name="id">The unique identifier of the announcement to retrieve.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
    /// If successful, the result contains the <see cref="AnnouncementDto"/> object;
    /// otherwise, it contains an error indicating the announcement was not found.
    /// </returns>
    public async Task<Result<AnnouncementDto>> GetById(Guid id)
    {
        var (exists, announcement) = await repository.IsRecordExist(id);

        if (!exists)
        {
            return Result<AnnouncementDto>.Failure(HttpStatusCode.NotFound, "The announcement was not found");
        }

        var announcementDto = mapper.Map<AnnouncementDto>(announcement);

        return Result<AnnouncementDto>.Success(announcementDto);
    }

    /// <summary>
    /// Creates a new announcement in the system for a specified user.
    /// </summary>
    /// <param name="createAnnouncementDto">
    /// An object containing the data required to create a new announcement.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
    /// The result indicates whether the creation was successful or provides details about the failure.
    /// </returns>
    /// <exception cref="UnauthorizedAccessException">
    /// Thrown if the user with the specified <paramref name="userId"/> does not exist in the system.
    /// </exception>
    public async Task<Result> Create(CreateAnnouncementDto createAnnouncementDto)
    {
        var announcementToCreate = mapper.Map<Announcement>(createAnnouncementDto);

        var (exists, vehicleModel) = await vehicleModelsRepository.IsRecordExist(createAnnouncementDto.VehicleModelId);

        if (!exists)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        var user = await usersRepository.GetByEmail(createAnnouncementDto.UserEmail) ?? throw new UnauthorizedAccessException($"User with {createAnnouncementDto.UserEmail} email doesn't exist in the sistem.");

        announcementToCreate.Vehicle = vehicleModel;
        announcementToCreate.Owner = user;

        var isCreated = await repository.Create(announcementToCreate);

        return isCreated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The announcement was not created.");
    }

    /// <summary>
    /// Updates an existing announcement in the system.
    /// </summary>
    /// <param name="updateAnnouncementDto">
    /// An object containing the updated data for the announcement and its associated vehicle model.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
    /// The result indicates whether the update was successful or provides details about the failure.
    /// </returns>
    public async Task<Result> Update(UpdateAnnouncementDto updateAnnouncementDto)
    {
        var (announcementExists, announcementToUpdate) = await repository.IsRecordExist(updateAnnouncementDto.Id);

        if (!announcementExists)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The announcement was not found.");
        }

        var (vehicleModelExists, _) = await vehicleModelsRepository.IsRecordExist(updateAnnouncementDto.Vehicle.Id);

        if (!vehicleModelExists)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        mapper.Map(updateAnnouncementDto, announcementToUpdate);

        var isUpdated = await repository.Update(announcementToUpdate);

        return isUpdated ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The announcement was not updated.");
    }

    /// <summary>
    /// Deletes an existing announcement from the system.
    /// </summary>
    /// <param name="id">
    /// The unique identifier of the announcement to be deleted.
    /// </param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
    /// The result indicates whether the deletion was successful or provides details about the failure.
    /// </returns>
    public async Task<Result> Delete(Guid id)
    {
        var (exists, announcementToDelete) = await repository.IsRecordExist(id);

        if (!exists)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The announcement was not found.");
        }

        var isDeleted = await repository.Delete(announcementToDelete);

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The announcement was not deleted.");
    }
}
