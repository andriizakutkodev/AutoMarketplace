namespace Application.Interfaces;

using Application.DTOs;
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

    /// <summary>
    /// Retrieves user information based on the provided user ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation.
    /// The result contains a <see cref="Result{T}"/> object with a <see cref="UserInfoDto"/>
    /// containing user information if the operation is successful.
    /// </returns>
    Task<Result<UserInfoDto>> GetUserInfo(Guid id);
}
