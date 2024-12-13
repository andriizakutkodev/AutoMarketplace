namespace Application.Interfaces;

using Domain.Entities;
using Infrastructure.Results;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Defines the contract for a service responsible for user-related operations such as retrieving and creating users.
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the user if found, or an error result if no user exists with the given email.
    /// </returns>
    Task<Result<User>> GetByEmail(string email);

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <param name="user">The user object containing the details of the new user.</param>
    /// <returns>
    /// A <see cref="Result"/> indicating the success or failure of the user creation process.
    /// </returns>
    Task<Result> Create(User user);

    /// <summary>
    /// Uploads an image file and returns the result containing the uploaded image object.
    /// </summary>
    /// <param name="file">The image file to be uploaded.</param>
    /// <returns>A task representing the asynchronous operation, containing the result with the uploaded image object.</returns>
    Task<Result<Image>> UploadImage(IFormFile file);
}
