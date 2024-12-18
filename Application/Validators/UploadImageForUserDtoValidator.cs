namespace Application.Validators;

using Application.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;

/// <summary>
/// Validator for the UploadImageForUserDto class.
/// Ensures that the UserId and ImageFile properties meet the required criteria.
/// </summary>
public class UploadImageForUserDtoValidator : AbstractValidator<UploadImageForUserDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UploadImageForUserDtoValidator"/> class.
    /// Sets up validation rules for the UserId and ImageFile properties.
    /// </summary>
    public UploadImageForUserDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().WithMessage("User's id is required.");
        RuleFor(x => x.ImageFile)
            .NotNull().WithMessage("Image file is required.")
            .Must(IsValidFileType).WithMessage("Invalid file type. Only PNG and JPEG images are allowed.")
            .Must(IsValidFileSize).WithMessage("File size must not exceed 5 MB.");
    }

    /// <summary>
    /// Checks whether the file type of the uploaded image is valid.
    /// </summary>
    /// <param name="file">The uploaded image file.</param>
    /// <returns>True if the file type is JPEG or PNG; otherwise, false.</returns>
    private bool IsValidFileType(IFormFile file)
    {
        if (file == null)
        {
            return false;
        }

        var allowedTypes = new[] { "image/jpeg", "image/png" };
        return allowedTypes.Contains(file.ContentType);
    }

    /// <summary>
    /// Checks whether the file size of the uploaded image is within the allowed limit.
    /// </summary>
    /// <param name="file">The uploaded image file.</param>
    /// <returns>True if the file size is less than or equal to 5 MB; otherwise, false.</returns>
    private bool IsValidFileSize(IFormFile file)
    {
        const long maxSizeInBytes = 5 * 1024 * 1024;
        return file.Length <= maxSizeInBytes;
    }
}
