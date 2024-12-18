namespace Application.Validators;

using Application.DTOs;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="CreateAnnouncementDto"/> class.
/// </summary>
public class CreateAnnouncementDtoValidator : AbstractValidator<CreateAnnouncementDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateAnnouncementDtoValidator"/> class.
    /// Defines validation rules for the <see cref="CreateAnnouncementDto"/> object.
    /// </summary>
    public CreateAnnouncementDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().NotNull().WithMessage("Title is required.");
        RuleFor(x => x.Description)
            .NotEmpty().NotNull().WithMessage("Description is required.");
        RuleFor(x => x.Price)
            .Must(x => x > 0).WithMessage("Price should be more than 0.");
        RuleFor(x => x.Mileage)
            .Must(x => x > 0).WithMessage("Mileage should be more than 0.");
        RuleFor(x => x.VehicleModelId)
            .NotEmpty().NotNull().WithMessage("Vehicle model id is required.");
        RuleFor(x => x.UserEmail)
            .NotEmpty().NotNull().WithMessage("User's email is required.");
    }
}