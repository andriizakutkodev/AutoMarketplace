namespace Application.DTOs;

/// <summary>
/// Represents a Data Transfer Object (DTO) containing user information.
/// </summary>
public class UserInfoDto
{
    /// <summary>
    /// Gets or sets the email address of the user.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the surname (last name) of the user.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    /// Gets or sets the authentication token for the user.
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    /// Gets or sets the URL of the user's profile image.
    /// </summary>
    public string ImgUrl { get; set; }
}
