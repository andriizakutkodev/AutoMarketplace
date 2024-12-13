namespace Application.Interfacesl;

using Domain.Entities;
using Infrastructure.Results;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Provides functionality to manage image operations such as uploading and deleting images.
/// </summary>
public interface IImageManageService
{
    /// <summary>
    /// Uploads an image file and returns the result containing the URL of the uploaded image.
    /// </summary>
    /// <param name="file">The image file to be uploaded.</param>
    /// <param name="imagesFolderName">The images folder name to store.</param>
    /// <returns>A task representing the asynchronous operation, containing the result with the URL of the uploaded image.</returns>
    Task<Result<Image>> Upload(IFormFile file, string imagesFolderName);

    /// <summary>
    /// Deletes an image from the server using its URL.
    /// </summary>
    /// <param name="imgUrl">The URL of the image to be deleted.</param>
    /// <returns>A task representing the asynchronous operation, containing the result of the deletion.</returns>
    Task<Result> Remove(string imgUrl);
}
