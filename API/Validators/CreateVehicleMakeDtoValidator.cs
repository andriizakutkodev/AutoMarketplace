namespace API.Validators;

using Application.DTOs.Requests;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="CreateVehicleMakeDto"/> class.
/// </summary>
public class CreateVehicleMakeDtoValidator : AbstractValidator<CreateVehicleMakeDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateVehicleMakeDtoValidator"/> class.
    /// Defines validation rules for creating a vehicle make.
    /// </summary>
    public CreateVehicleMakeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("Vehicle make name is required.");
        RuleFor(x => x.VehicleTypeId)
            .NotEmpty().NotNull().WithMessage("Vehicle type id is required.");
    }
}
