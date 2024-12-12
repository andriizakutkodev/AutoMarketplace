namespace API.Validators;

using Application.DTOs.Requests;
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
        RuleFor(x => x.VehicleMakeId)
            .NotEmpty().NotNull().WithMessage("The vehicle make id should not be null or empty.");
        RuleFor(x => x.FuelTypeId)
            .NotEmpty().NotNull().WithMessage("The fuel type id should not be null or empty.");
        RuleFor(x => x.EngineTypeId)
            .NotEmpty().NotNull().WithMessage("The engine type id should not be null or empty.");
    }
}
