namespace Application.DTOs;

/// <summary>
/// Represents the data transfer object (DTO) for user registration information.
/// Used to encapsulate the necessary data for creating a new user.
/// </summary>
public class RegisterDto
{
    /// <summary>
    /// Gets or sets the email address of the user to be registered.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user to be registered.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the surname (last name) of the user to be registered.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Gets or sets the phone number of the user to be registered.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the password of the user to be registered.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the URL of the user's profile image.
    /// </summary>
    public string ImgUrl { get; set; }
}
