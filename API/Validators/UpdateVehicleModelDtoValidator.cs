namespace API.Validators;

using Application.DTOs;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="UpdateVehicleModelDto"/> class.
/// </summary>
public class UpdateVehicleModelDtoValidator : AbstractValidator<UpdateVehicleModelDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateVehicleModelDtoValidator"/> class.
    /// /// Defines validation rules for the <see cref="UpdateVehicleModelDto"/> object.
    /// </summary>
    public UpdateVehicleModelDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().WithMessage("The vehicle model id should not be null or empty.");
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("The name should not be null or empty.");
        RuleFor(x => x.ReleaseDate)
            .NotEmpty().NotNull().WithMessage("The release date should not be null or empty.");
        RuleFor(x => x.EngineCapacity)
            .NotEmpty().NotNull().WithMessage("The engine capacity should not be null or empty");
        RuleFor(x => x.Make)
            .NotEmpty().NotNull().WithMessage("The make name should not be null or empty.")
            .IsInEnum();
        RuleFor(x => x.EngineType)
            .NotEmpty().NotNull().WithMessage("The vehicle type should not be null or empty.")
            .IsInEnum();
        RuleFor(x => x.EngineType)
            .NotEmpty().NotNull().WithMessage("The engine type name should not be null or empty.")
            .IsInEnum();
    }
}
