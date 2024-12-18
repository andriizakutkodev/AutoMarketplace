namespace Application.Validators;

using Application.DTOs;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="UpdateAnnouncementDto"/> class.
/// </summary>
public class UpdateAnnouncementDtoValidator : AbstractValidator<UpdateAnnouncementDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateAnnouncementDtoValidator"/> class.
    /// Validates the properties of <see cref="UpdateAnnouncementDto"/> for updating an announcement.
    /// </summary>
    /// <param name="validator">
    /// An instance of <see cref="UpdateVehicleModelDtoValidator"/> used to validate the nested <see cref="VehicleModelDto"/> object.
    /// </param>
    public UpdateAnnouncementDtoValidator(UpdateVehicleModelDtoValidator validator)
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().WithMessage("Id is required.");
        RuleFor(x => x.Description)
            .NotEmpty().NotNull().WithMessage("Description is required.");
        RuleFor(x => x.Price)
            .Must(x => x > 0).WithMessage("Price should be more than 0.");
        RuleFor(x => x.Mileage)
            .Must(x => x > 0).WithMessage("Mileage should be more than 0.");
        RuleFor(x => x.Status)
            .IsInEnum();
        RuleFor(x => x.Vehicle)
            .SetValidator(validator);
    }
}