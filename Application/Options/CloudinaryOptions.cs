namespace Application.Options;

/// <summary>
/// Represents configuration options for connecting to the Cloudinary service.
/// </summary>
public class CloudinaryOptions
{
    /// <summary>
    /// Gets or sets the name of the Cloudinary cloud.
    /// </summary>
    public string CloudName { get; set; }

    /// <summary>
    /// Gets or sets the API key for authenticating with Cloudinary.
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the API secret for authenticating with Cloudinary.
    /// </summary>
    public string ApiSecret { get; set; }
}
