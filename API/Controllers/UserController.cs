namespace API.Controllers;

using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for handling actions for users.
/// </summary>
public class UserController(IImageService imageService) : BaseAPIController
{
    /// <summary>
    /// Uploads an image for a specific user.
    /// </summary>
    /// <param name="uploadImageForUserDto">The DTO containing the user ID and image file to upload.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> indicating the outcome of the upload operation.
    /// Returns a success or failure response based on the result of the image upload.
    /// </returns>
    [HttpPost("image")]
    public async Task<IActionResult> UploadImage(UploadImageForUserDto uploadImageForUserDto)
    {
        return HandleResult(await imageService.UploadImageForUser(uploadImageForUserDto));
    }

    /// <summary>
    /// Removes the image for a specific user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user whose image will be removed.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> indicating the outcome of the image removal operation.
    /// Returns a success or failure response based on whether the image was successfully removed.
    /// </returns>
    [HttpDelete("{id}/image")]
    public async Task<IActionResult> RemoveImage(Guid id)
    {
        return HandleResult(await imageService.RemoveImageForUser(id));
    }
}
