namespace Application.Services;

using System.Net;
using Application.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Domain.Entities;
using Infrastructure.Results;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Service for managing image operations using Cloudinary.
/// </summary>
public class FileStorageService : IFileStorageService
{
    private readonly Cloudinary _cloudinary;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileStorageService"/> class with a Cloudinary instance.
    /// </summary>
    /// <param name="cloudinary">The Cloudinary instance for handling image operations.</param>
    public FileStorageService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    /// <summary>
    /// Uploads an image to Cloudinary with the specified public ID.
    /// </summary>
    /// <param name="file">The image file to be uploaded.</param>
    /// <returns>A task representing the asynchronous operation, containing the result with the URL of the uploaded image.</returns>
    public async Task<Result<Image>> Upload(IFormFile file)
    {
        var publicId = Guid.NewGuid().ToString();

        using var stream = file.OpenReadStream();

        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream),
            PublicId = publicId,
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);

        if (uploadResult.StatusCode != HttpStatusCode.OK)
        {
            return Result<Image>.Failure(HttpStatusCode.BadRequest, $"Failed to upload image: {uploadResult.Error?.Message}");
        }

        var image = new Image
        {
            PublicId = publicId,
            Url = uploadResult.SecureUrl.ToString(),
        };

        return Result<Image>.Success(image);
    }

    /// <summary>
    /// Removes an image from Cloudinary using the specified public ID.
    /// </summary>
    /// <param name="publicId">The public ID of the image to be deleted.</param>
    /// <returns>A task representing the asynchronous operation, containing the result of the deletion.</returns>
    public async Task<Result> Remove(string publicId)
    {
        var deletionParams = new DeletionParams(publicId);

        var result = await _cloudinary.DestroyAsync(deletionParams);

        if (result.StatusCode == HttpStatusCode.OK && result.Result == "ok")
        {
            return Result.Success();
        }

        if (result.StatusCode == HttpStatusCode.OK && result.Result == "not found")
        {
            return Result.Failure(HttpStatusCode.NotFound, $"Failed to delete image: {result.Error?.Message}");
        }

        return Result.Failure(HttpStatusCode.BadRequest, $"Failed to delete image: {result.Error?.Message}");
    }
}
