namespace Application.Services;

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Results;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Implements the <see cref="IAnnouncementService"/> interface to handle business logic for managing posts.
/// Provides functionality for creating, retrieving, updating, and deleting posts by interacting with the repository.
/// </summary>
public class AnnouncementService(AppDbContext context, IMapper mapper) : IAnnouncementService
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
        var announcements = await context.Announcements.ToListAsync();

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
        var announcement = await context.Announcements.FirstOrDefaultAsync(a => a.Id == id);

        if (announcement is null)
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

        var vehicleModel = await context.VehicleModels.FirstOrDefaultAsync(vm => vm.Id == createAnnouncementDto.VehicleModelId);

        if (vehicleModel is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        var user = await context.Users.FirstOrDefaultAsync(u => u.Email == createAnnouncementDto.UserEmail) ?? throw new UnauthorizedAccessException($"User with {createAnnouncementDto.UserEmail} email doesn't exist in the sistem.");

        announcementToCreate.Vehicle = vehicleModel;
        announcementToCreate.Owner = user;

        context.Announcements.Add(announcementToCreate);

        var isCreated = await context.SaveChangesAsync() > 0;

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
        var announcementToUpdate = await context.Announcements.FirstOrDefaultAsync(a => a.Id == updateAnnouncementDto.Id);

        if (announcementToUpdate is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The announcement was not found.");
        }

        var vehicleModel = await context.VehicleModels.FirstOrDefaultAsync(vm => vm.Id == updateAnnouncementDto.Vehicle.Id);

        if (vehicleModel is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The vehicle model was not found.");
        }

        mapper.Map(updateAnnouncementDto, announcementToUpdate);

        context.Announcements.Update(announcementToUpdate);

        var isUpdated = await context.SaveChangesAsync() > 0;

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
        var announcementToDelete = await context.Announcements.FirstOrDefaultAsync(a => a.Id == id);

        if (announcementToDelete is null)
        {
            return Result.Failure(HttpStatusCode.NotFound, "The announcement was not found.");
        }

        context.Announcements.Remove(announcementToDelete);

        var isDeleted = await context.SaveChangesAsync() > 0;

        return isDeleted ? Result.Success() : Result.Failure(HttpStatusCode.BadRequest, "The announcement was not deleted.");
    }
}
