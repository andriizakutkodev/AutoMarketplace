namespace Application.Services;

using System.Net;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Interfacesl;
using Domain.Entities;
using Infrastructure.Results;
using Microsoft.AspNetCore.Http;
using Persistence.Interfaces;

/// <summary>
/// Represents the service responsible for managing business logic related to <see cref="User"/> entities.
/// </summary>
public class UsersService(
    IUsersRepository repository,
    IImageManageService imageManageService) : IUsersService
{
    private const string IMAGESFOLDERNAME = $"Images/Users";

    /// <summary>
    /// Creates a new <see cref="User"/> entity.
    /// </summary>
    /// <param name="user">The <see cref="User"/> entity to be created.</param>
    /// <returns>
    /// A <see cref="Task{TResult}"/> representing the asynchronous operation, with a <see cref="Result"/> object
    /// indicating success or failure of the creation process.
    /// </returns>
    public async Task<Result> Create(User user)
    {
        if (await repository.IsUserWithEmailExists(user.Email))
        {
            return Result.Failure(HttpStatusCode.BadRequest, $"{user.Email} email has already taken. Please choose another one.");
        }

        var isCreated = await repository.Create(user);

        if (isCreated)
        {
            return Result.Success();
        }
        else
        {
            return Result.Failure(HttpStatusCode.BadRequest, "User was not created successfully.");
        }
    }

    /// <summary>
    /// Retrieves a user by their email address.
    /// </summary>
    /// <param name="email">The email address of the user to retrieve.</param>
    /// <returns>
    /// A <see cref="Result{T}"/> containing the user if found, or an error result if no user exists with the given email.
    /// </returns>
    public async Task<Result<User>> GetByEmail(string email)
    {
        if (!await repository.IsUserWithEmailExists(email))
        {
            return Result<User>.Failure(HttpStatusCode.BadRequest, $"User with {email} email doesn't exist. Please register or try with different one.");
        }

        return Result<User>.Success(await repository.GetByEmail(email));
    }

    /// <summary>
    /// Uploads an image file and returns the result containing the uploaded image object.
    /// </summary>
    /// <param name="file">The image file to be uploaded.</param>
    /// <returns>A task representing the asynchronous operation, containing the result with the uploaded image object.</returns>
    public async Task<Result<Image>> UploadImage(IFormFile file)
    {
        var publicId = $"{IMAGESFOLDERNAME}/{Guid.NewGuid()}";

        var uploadResult = await imageManageService.Upload(file, publicId);

        if (uploadResult.IsSuccess)
        {
            var image = new Image
            {
                PublicId = publicId,
                Url = uploadResult.Data,
            };

            return Result<Image>.Success(image);
        }

        return Result<Image>.Failure(uploadResult.StatusCode, uploadResult.Message);
    }
}
