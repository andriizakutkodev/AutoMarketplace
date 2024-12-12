namespace Application.DTOs;

/// <summary>
/// Data transfer object for creating a new announcement model.
/// </summary>
public class CreateAnnouncementDto
{
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
    /// Gets or sets the vehicle model identifier.
    /// </summary>
    public Guid VehicleModelId { get; set; }

    /// <summary>
    ///  Gets or sets the user's unique identifier.
    /// </summary>
    public string UserEmail { get; set; }
}
