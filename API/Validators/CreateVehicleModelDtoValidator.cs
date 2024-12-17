namespace API.Validators;

using Application.DTOs;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="CreateVehicleModelDto"/> class.
/// </summary>
public class CreateVehicleModelDtoValidator : AbstractValidator<CreateVehicleModelDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateVehicleModelDtoValidator"/> class.
    /// /// Defines validation rules for the <see cref="CreateVehicleModelDto"/> object.
    /// </summary>
    public CreateVehicleModelDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("The name should not be null or empty.");
        RuleFor(x => x.ReleaseDate)
            .NotEmpty().NotNull().WithMessage("The release date should not be null or empty.");
        RuleFor(x => x.EngineCapacity)
            .NotEmpty().NotNull().WithMessage("The engine capacity should not be null or empty");
        RuleFor(x => x.Make)
            .NotEmpty().NotNull().WithMessage("The vehicle make should not be null or empty.")
            .IsInEnum();
        RuleFor(x => x.VehicleType)
            .NotEmpty().NotNull().WithMessage("The vehicle type should not be null or empty.")
            .IsInEnum();
        RuleFor(x => x.EngineType)
            .NotEmpty().NotNull().WithMessage("The engine type should not be null or empty.")
            .IsInEnum();
    }
}
