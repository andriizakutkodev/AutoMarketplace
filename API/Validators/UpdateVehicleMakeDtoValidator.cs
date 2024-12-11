namespace API.Validators;

using Application.DTOs.Requests;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="UpdateVehicleMakeDto"/> class.
/// </summary>
public class UpdateVehicleMakeDtoValidator : AbstractValidator<UpdateVehicleMakeDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateVehicleMakeDtoValidator"/> class.
    /// Defines validation rules for updating a vehicle make.
    /// </summary>
    public UpdateVehicleMakeDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().WithMessage("The vehicle make id is required.");
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("The vehicle name is required.");
        RuleFor(x => x.Type)
           .NotNull().WithMessage("The vehicle type is required.");
        RuleFor(x => x.Type.Id)
           .NotNull().WithMessage("The vehicle type id is required.");
        RuleFor(x => x.Type.Name)
           .NotNull().WithMessage("The vehicle type name is required.");
    }
}
