namespace Application.Services;

using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Results;
using Persistence.Interfaces;

/// <summary>
/// Service for handling image upload and removal operations for users and announcements.
/// </summary>
/// <param name="fileStorageService">Service for interacting with file storage.</param>
/// <param name="usersRepository">Repository for accessing user data.</param>
/// <param name="announcementRepository">Repository for accessing announcement data.</param>
public class ImageService(
    IFileStorageService fileStorageService,
    IUsersRepository usersRepository,
    IImageRepository imageRepository,
    IAnnouncementRepository announcementRepository) : IImageService
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
            var user = await usersRepository.GetByEmail(uploadImageForUserDto.UserEmail);

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

            var isImageCreated = await imageRepository.Create(uploadResult.Data);

            if (!isImageCreated)
            {
                await fileStorageService.Remove(publicId);
                return Result.Failure(HttpStatusCode.BadRequest, "Image was not uploaded.");
            }

            user.Image = uploadResult.Data;

            var isUpdated = await usersRepository.Update(user);

            if (!isUpdated)
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
    /// <param name="userEmail">The email of the user whose image will be removed.</param>
    /// <returns>
    /// A <see cref="Result"/> indicating success or failure of the operation.
    /// Returns a failure if the user does not exist, the image fails to delete from storage,
    /// or the user update operation is unsuccessful.
    /// </returns>
    public async Task<Result> RemoveImageForUser(string userEmail)
    {
        var isImageDeleted = default(bool);
        var isUserUpdated = default(bool);
        var imageToDelete = default(Image);
        var user = default(User);

        try
        {
            user = await usersRepository.GetByEmail(userEmail);

            if (user is null)
            {
                return Result.Failure(HttpStatusCode.NotFound, "User was not found.");
            }

            imageToDelete = user.Image;

            if (imageToDelete is null)
            {
                return Result.Failure(HttpStatusCode.BadRequest, "User does not have an image to delete.");
            }

            isImageDeleted = await imageRepository.Delete(imageToDelete);
            user.Image = default;

            isUserUpdated = await usersRepository.Update(user);

            if (!isImageDeleted || !isUserUpdated)
            {
                return Result.Failure(HttpStatusCode.BadRequest, "Image was not removed.");
            }

            var removeImageFromStorageResult = await fileStorageService.Remove(imageToDelete.PublicId);

            if (!removeImageFromStorageResult.IsSuccess)
            {
                if (removeImageFromStorageResult.StatusCode != HttpStatusCode.NotFound)
                {
                    await imageRepository.Create(imageToDelete);
                    user.Image = imageToDelete;
                    await usersRepository.Update(user);

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
                await imageRepository.Create(imageToDelete);
            }
            else if (isImageDeleted && isUserUpdated)
            {
                await imageRepository.Create(imageToDelete);
                user.Image = imageToDelete;
                await usersRepository.Update(user);
            }

            throw;
        }
    }

    public Task<Result> UploadImagesForAnnouncement(UploadImagesForAnnouncementDto uploadImagesForAnnouncementDto)
    {
        throw new NotImplementedException();
    }
}
