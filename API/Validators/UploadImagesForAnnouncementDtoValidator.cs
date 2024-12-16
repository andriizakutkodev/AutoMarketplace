namespace API.Validators;

using Application.DTOs;
using FluentValidation;

/// <summary>
/// Validator for the UploadImagesForAnnouncementDto class.
/// Ensures that the AnnouncementId and ImageFiles properties meet the required validation criteria.
/// </summary>
public class UploadImagesForAnnouncementDtoValidator : AbstractValidator<UploadImagesForAnnouncementDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UploadImagesForAnnouncementDtoValidator"/> class.
    /// Defines validation rules for AnnouncementId and each image file in the ImageFiles collection.
    /// </summary>
    public UploadImagesForAnnouncementDtoValidator()
    {
        RuleFor(x => x.AnnouncementId)
            .NotEmpty().WithMessage("AnnouncementId is required.")
            .NotEqual(Guid.Empty).WithMessage("AnnouncementId cannot be an empty GUID.");
        RuleFor(x => x.ImageFiles)
            .NotNull().WithMessage("Image files collection is required.")
            .Must(files => files != null && files.Count != 0)
            .WithMessage("At least one image file must be provided.");
        RuleForEach(x => x.ImageFiles).ChildRules(file =>
        {
            file.RuleFor(f => f)
                .NotNull().WithMessage("Image file cannot be null.");
            file.RuleFor(f => f.ContentType)
                .NotEmpty().WithMessage("File type cannot be empty.")
                .Must(type => IsAllowedFileType(type))
                .WithMessage("Invalid file type. Only PNG and JPEG images are allowed.");

            file.RuleFor(f => f.Length)
                .LessThanOrEqualTo(5 * 1024 * 1024)
                .WithMessage("File size must not exceed 5 MB.");
        });
    }

    /// <summary>
    /// Checks if the provided file content type is allowed (only PNG and JPEG).
    /// </summary>
    /// <param name="contentType">The MIME type of the file.</param>
    /// <returns>True if the file type is allowed; otherwise, false.</returns>
    private static bool IsAllowedFileType(string contentType)
    {
        var allowedTypes = new[] { "image/jpeg", "image/png" };
        return allowedTypes.Contains(contentType);
    }
}
