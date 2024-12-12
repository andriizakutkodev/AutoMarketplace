namespace Application.Services;

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Results;
using Persistence.Interfaces;

/// <summary>
/// Implements the <see cref="IAnnouncementsService"/> interface to handle business logic for managing posts.
/// Provides functionality for creating, retrieving, updating, and deleting posts by interacting with the repository.
/// </summary>
public class AnnouncementsService(
    IAnnouncementsRepository repository,
    IVehicleModelsRepository vehicleModelsRepository,
    IUsersRepository usersRepository) : IAnnouncementsService
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

        var announcementDtos = announcements.Select(announcement => new AnnouncementDto
        {
            Id = announcement.Id,
            Title = announcement.Title,
            Description = announcement.Description,
            Price = announcement.Price,
            Mileage = announcement.Mileage,
            IsHot = announcement.IsHot,
            IsVerified = announcement.IsVerified,
            Status = announcement.Status.ToString(),
            CreatedAt = announcement.CreatedAt,
            PublishAt = announcement.PublishAt,
            Vehicle = new VehicleModelDto
            {
                Id = announcement.Vehicle.Id,
                Name = announcement.Vehicle.Name,
                EngineCapacity = announcement.Vehicle.EngineCapacity,
                Make = announcement.Vehicle.Make.ToString(),
                EngineType = announcement.Vehicle.EngineType.ToString(),
                ReleaseDate = announcement.Vehicle.ReleaseDate,
            },
        }).ToList();

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
        var announcement = await repository.GetById(id);

        if (announcement is null)
        {
            return Result<AnnouncementDto>.Failure(HttpStatusCode.NotFound, "The announcement was not found");
        }

        var announcementDto = new AnnouncementDto
        {
            Id = announcement.Id,
            Title = announcement.Title,
            Description = announcement.Description,
            Price = announcement.Price,
            Mileage = announcement.Mileage,
            IsHot = announcement.IsHot,
            IsVerified = announcement.IsVerified,
            Status = announcement.Status.ToString(),
            CreatedAt = announcement.CreatedAt,
            PublishAt = announcement.PublishAt,
            Vehicle = new VehicleModelDto
            {
                Id = announcement.Vehicle.Id,
                Name = announcement.Vehicle.Name,
                EngineCapacity = announcement.Vehicle.EngineCapacity,
                Make = announcement.Vehicle.Make.ToString(),
                EngineType = announcement.Vehicle.EngineType.ToString(),
                ReleaseDate = announcement.Vehicle.ReleaseDate,
            },
        };

        return Result<AnnouncementDto>.Success(announcementDto);
    }

    /// <summary>
    /// Creates a new announcement in the system for a specified user.
    /// </summary>
    /// <param name="createAnnouncementDto">
    /// An object containing the data required to create a new announcement.
    /// </param>
    /// <param name="userId">The unique identifier of the user creating the announcement.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
    /// The result indicates whether the creation was successful or provides details about the failure.
    /// </returns>
    /// <exception cref="UnauthorizedAccessException">
    /// Thrown if the user with the specified <paramref name="userId"/> does not exist in the system.
    /// </exception>
    public async Task<Result> Create(CreateAnnouncementDto createAnnouncementDto, Guid userId)
    {
        var vehicleModel = await vehicleModelsRepository.GetById(createAnnouncementDto.VehicleModelId);

        if (vehicleModel is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        var user = await usersRepository.GetById(userId) ?? throw new UnauthorizedAccessException($"User with id {userId} doesn't exist in the sistem.");

        var announcementToCreate = new Announcement
        {
            Id = Guid.NewGuid(),
            Title = createAnnouncementDto.Title,
            Description = createAnnouncementDto.Description,
            Price = createAnnouncementDto.Price,
            Mileage = createAnnouncementDto.Mileage,
            IsHot = false,
            IsVerified = false,
            Status = AnnouncementStatus.Pending,
            CreatedAt = DateTime.UtcNow,
            Vehicle = vehicleModel,
            Owner = user,
        };

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
        var announcementToUpdate = await repository.GetById(updateAnnouncementDto.Id);

        if (announcementToUpdate is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The announcement was not found.");
        }

        var vehicleToUpdate = await vehicleModelsRepository.GetById(updateAnnouncementDto.Vehicle.Id);

        if (vehicleToUpdate is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        vehicleToUpdate.Name = updateAnnouncementDto.Vehicle.Name;
        vehicleToUpdate.EngineCapacity = updateAnnouncementDto.Vehicle.EngineCapacity;
        vehicleToUpdate.Make = updateAnnouncementDto.Vehicle.Make;
        vehicleToUpdate.EngineType = updateAnnouncementDto.Vehicle.EngineType;
        vehicleToUpdate.ReleaseDate = updateAnnouncementDto.Vehicle.ReleaseDate;

        announcementToUpdate.Title = updateAnnouncementDto.Title;
        announcementToUpdate.Description = updateAnnouncementDto.Description;
        announcementToUpdate.Price = updateAnnouncementDto.Price;
        announcementToUpdate.Mileage = updateAnnouncementDto.Mileage;
        announcementToUpdate.IsHot = updateAnnouncementDto.IsHot;
        announcementToUpdate.IsVerified = updateAnnouncementDto.IsVerified;
        announcementToUpdate.Status = updateAnnouncementDto.Status;
        announcementToUpdate.CreatedAt = announcementToUpdate.CreatedAt;
        announcementToUpdate.PublishAt = announcementToUpdate.PublishAt;
        announcementToUpdate.Vehicle = vehicleToUpdate;

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
        var announcementToDelete = await repository.GetById(id);

        if (announcementToDelete is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The announcement was not found.");
        }

        var isDeleted = await repository.Delete(announcementToDelete);

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The announcement was not deleted.");
    }
}
