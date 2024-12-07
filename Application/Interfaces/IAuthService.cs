namespace Application.Interfaces;

using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Infrastructure.Results;

/// <summary>
/// Represents a service interface for user authentication and management operations.
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Authenticates a user and returns user information if the login is successful.
    /// </summary>
    /// <param name="loginDto">The login details (email and password) for the user.</param>
    /// <returns>A <see cref="Result{UserInfoDto}"/> containing the user's information if login is successful, or an error message if not.</returns>
    Task<Result<UserInfoDto>> Login(LoginDto loginDto);

    /// <summary>
    /// Registers a new user and returns user information upon successful registration.
    /// </summary>
    /// <param name="registerDto">The registration details (email, name, etc.) for the new user.</param>
    /// <returns>A <see cref="Result{UserInfoDto}"/> containing the user's information if registration is successful, or an error message if not.</returns>
    Task<Result<UserInfoDto>> Register(RegisterDto registerDto);
}
