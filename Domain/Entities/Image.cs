namespace Domain.Entities;

/// <summary>
/// Represents an image entity with associated properties and relationships.
/// </summary>
public class Image : BaseEntity
{
    /// <summary>
    /// Gets or sets a value indicating whether this image is the main image.
    /// </summary>
    public bool IsMain { get; set; }

    /// <summary>
    /// Gets or sets the URL of the image.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets the collection of announcements associated with this image.
    /// </summary>
    public virtual ICollection<Announcement> Announcements { get; set; }
}
