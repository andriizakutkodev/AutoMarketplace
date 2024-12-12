namespace Application.DTOs;

/// <summary>
/// Represents the data transfer object (DTO) for user login information.
/// Used to encapsulate the email and password required for user authentication.
/// </summary>
public class LoginDto
{
    /// <summary>
    /// Gets or sets the email address of the user attempting to log in.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password of the user attempting to log in.
    /// </summary>
    public string Password { get; set; }
}
