namespace Application.Validators;

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
            .NotEmpty().NotNull().WithMessage("The vehicle model id is required.");
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("The name is required.");
        RuleFor(x => x.ReleaseDate)
            .NotEmpty().NotNull().WithMessage("The release date is required.");
        RuleFor(x => x.EngineCapacity)
            .NotEmpty().NotNull().WithMessage("The engine capacity is required.");
        RuleFor(x => x.Make)
            .NotEmpty().NotNull().WithMessage("The make name is required.")
            .IsInEnum();
        RuleFor(x => x.EngineType)
            .NotEmpty().NotNull().WithMessage("The vehicle type is required.")
            .IsInEnum();
        RuleFor(x => x.EngineType)
            .NotEmpty().NotNull().WithMessage("The engine type name is required.")
            .IsInEnum();
    }
}
