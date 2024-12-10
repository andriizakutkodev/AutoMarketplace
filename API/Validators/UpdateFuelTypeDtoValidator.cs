namespace API.Validators;

using Application.DTOs.Requests;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="UpdateFuelTypeDto"/> class.
/// </summary>
public class UpdateFuelTypeDtoValidator : AbstractValidator<UpdateFuelTypeDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateFuelTypeDtoValidator"/> class.
    /// Defines validation rules for the <see cref="UpdateFuelTypeDto"/> object.
    /// </summary>
    public UpdateFuelTypeDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The fuel type id value cannot be empty.");
        RuleFor(x => x.NewName)
            .NotEmpty().WithMessage("The fuel name should not be empty.");
    }
}
