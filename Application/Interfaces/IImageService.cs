namespace Application.Interfaces;

using Application.DTOs;
using Infrastructure.Results;

/// <summary>
/// Provides methods for managing images.
/// </summary>
public interface IImageService
{
    /// <summary>
    /// Uploads an image for a specific user.
    /// </summary>
    /// <param name="uploadImageForUserDto">The DTO containing user ID and image file details.</param>
    /// <returns>A <see cref="Result"/> indicating the success or failure of the operation.</returns>
    Task<Result> UploadImageForUser(UploadImageForUserDto uploadImageForUserDto);

    /// <summary>
    /// Removes the uploaded image associated with a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose image is to be removed.</param>
    /// <returns>A <see cref="Result"/> indicating the success or failure of the operation.</returns>
    Task<Result> RemoveImageForUser(Guid userId);

    /// <summary>
    /// Uploads multiple images for a specific announcement.
    /// </summary>
    /// <param name="uploadImagesForAnnouncementDto">
    /// The DTO containing announcement ID and a collection of image files.
    /// </param>
    /// <returns>A <see cref="Result"/> indicating the success or failure of the operation.</returns>
    Task<Result> UploadImagesForAnnouncement(UploadImagesForAnnouncementDto uploadImagesForAnnouncementDto);
}
