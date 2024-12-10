namespace API.Validators;

using Application.DTOs.Requests;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="CreateFuelTypeDto"/> class.
/// </summary>
public class CreateFuelTypeDtoValidator : AbstractValidator<CreateFuelTypeDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateFuelTypeDtoValidator"/> class.
    /// Defines validation rules for the <see cref="CreateFuelTypeDto"/> object.
    /// </summary>
    public CreateFuelTypeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The fuel type name should not be empty.")
            .MaximumLength(30).WithMessage("The fuel type name cannot be more than 30 characters.");
    }
}
