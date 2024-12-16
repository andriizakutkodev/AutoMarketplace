namespace Application.DTOs;

using Microsoft.AspNetCore.Http;

/// <summary>
/// Data transfer object for uploading an image for a specific user.
/// </summary>
public class UploadImageForUserDto
{
    /// <summary>
    /// Gets or sets the email of the user.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the image file to be uploaded.
    /// </summary>
    public IFormFile ImageFile { get; set; }
}
