namespace Application.DTOs;

using Domain.Enums;

/// <summary>
/// Data transfer object for updating an announcement model.
/// </summary>
public class UpdateAnnouncementDto
{
    /// <summary>
    /// Gets or sets the unique identifier for an announcement.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the title for an announcement.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the description for an announcement.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the price associated with the announcement.
    /// </summary>
    public double Price { get; set; }

    /// <summary>
    /// Gets or sets the mileage of the vehicle, typically measured in kilometers.
    /// </summary>
    public short Mileage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the announcement is marked as hot.
    /// </summary>
    public bool IsHot { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the announcement is verified or not.
    /// </summary>
    public bool IsVerified { get; set; }

    /// <summary>
    /// Gets or sets the release date of the vehicle (e.g., production date).
    /// </summary>
    public DateTimeOffset ReleaseDate { get; set; }

    /// <summary>
    /// Gets or sets the status of the announcement (e.g. pending, published, canceled).
    /// </summary>
    public AnnouncementStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the associated vehicle details for the announcement.
    /// </summary>
    public virtual UpdateVehicleModelDto Vehicle { get; set; }
}