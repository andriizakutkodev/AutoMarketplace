namespace Application.DTOs;

using Microsoft.AspNetCore.Http;

/// <summary>
/// Data transfer object for uploading multiple images for a specific announcement.
/// </summary>
public class UploadImagesForAnnouncementDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the announcement.
    /// </summary>
    public Guid AnnouncementId { get; set; }

    /// <summary>
    /// Gets or sets the collection of image files to be uploaded.
    /// </summary>
    public ICollection<IFormFile> ImageFiles { get; set; }
}
