namespace Application.Services;

using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Results;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Service for handling image upload and removal operations for users and announcements.
/// </summary>
/// <param name="fileStorageService">Service for interacting with file storage.</param>
/// <param name="usersRepository">Repository for accessing user data.</param>
/// <param name="announcementRepository">Repository for accessing announcement data.</param>
public class ImageService(AppDbContext context, IFileStorageService fileStorageService) : IImageService
{
    /// <summary>
    /// Uploads an image for a specific user and updates the user's profile with the uploaded image.
    /// </summary>
    /// <param name="uploadImageForUserDto">The DTO containing the user ID and the image file to upload.</param>
    /// <returns>
    /// A <see cref="Result"/> indicating success or failure of the operation.
    /// Returns a failure if the user does not exist, the file fails to upload,
    /// or the user update operation is unsuccessful.
    /// </returns>
    public async Task<Result> UploadImageForUser(UploadImageForUserDto uploadImageForUserDto)
    {
        var publicId = string.Empty;

        try
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Id == uploadImageForUserDto.Id);

            if (user is null)
            {
                return Result.Failure(HttpStatusCode.NotFound, "User was not found.");
            }

            var uploadResult = await fileStorageService.Upload(uploadImageForUserDto.ImageFile, "user/images");

            if (!uploadResult.IsSuccess)
            {
                return Result.Failure(uploadResult.StatusCode, uploadResult.Message);
            }

            publicId = uploadResult.Data.PublicId;

            context.Images.Add(uploadResult.Data);

            user.Image = uploadResult.Data;

            context.Users.Update(user);

            var isSuccess = await context.SaveChangesAsync() > 0;

            if (!isSuccess)
            {
                await fileStorageService.Remove(uploadResult.Data.PublicId);
                return Result.Failure(HttpStatusCode.BadRequest, "Image was not uploaded.");
            }

            return Result.Success();
        }
        catch (Exception)
        {
            if (!string.IsNullOrEmpty(publicId))
            {
                await fileStorageService.Remove(publicId);
            }

            throw;
        }
    }

    /// <summary>
    /// Removes the image associated with a specific user from both storage and the user's profile.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose image will be removed.</param>
    /// <returns>
    /// A <see cref="Result"/> indicating success or failure of the operation.
    /// Returns a failure if the user does not exist, the image fails to delete from storage,
    /// or the user update operation is unsuccessful.
    /// </returns>
    public async Task<Result> RemoveImageForUser(Guid userId)
    {
        var isImageDeleted = default(bool);
        var isUserUpdated = default(bool);
        var imageToDelete = default(Image);
        var user = default(User);

        try
        {
            user = await context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user is null)
            {
                return Result.Failure(HttpStatusCode.NotFound, "User was not found.");
            }

            imageToDelete = user.Image;

            if (imageToDelete is null)
            {
                return Result.Failure(HttpStatusCode.BadRequest, "User does not have an image to delete.");
            }

            context.Images.Remove(imageToDelete);
            user.Image = default;

            context.Users.Update(user);

            var isSuccess = await context.SaveChangesAsync() > 0;

            if (!isSuccess)
            {
                return Result.Failure(HttpStatusCode.BadRequest, "Image was not removed.");
            }

            var removeImageFromStorageResult = await fileStorageService.Remove(imageToDelete.PublicId);

            if (!removeImageFromStorageResult.IsSuccess)
            {
                if (removeImageFromStorageResult.StatusCode != HttpStatusCode.NotFound)
                {
                    context.Images.Add(imageToDelete);

                    user.Image = imageToDelete;
                    context.Users.Update(user);

                    await context.SaveChangesAsync();

                    return Result.Failure(removeImageFromStorageResult.StatusCode, removeImageFromStorageResult.Message);
                }
                else
                {
                    return Result.Success();
                }
            }

            return Result.Success();
        }
        catch (Exception)
        {
            if (isImageDeleted)
            {
                context.Images.Add(imageToDelete);
                await context.SaveChangesAsync();
            }
            else if (isImageDeleted && isUserUpdated)
            {
                context.Images.Add(imageToDelete);
                user.Image = imageToDelete;
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }

            throw;
        }
    }

    public Task<Result> UploadImagesForAnnouncement(UploadImagesForAnnouncementDto uploadImagesForAnnouncementDto)
    {
        throw new NotImplementedException();
    }
}
