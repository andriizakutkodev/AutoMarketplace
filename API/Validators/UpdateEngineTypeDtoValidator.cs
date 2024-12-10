namespace API.Validators;

using Application.DTOs.Requests;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="UpdateEngineTypeDto"/> class.
/// </summary>
public class UpdateEngineTypeDtoValidator : AbstractValidator<UpdateEngineTypeDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateEngineTypeDtoValidator"/> class.
    /// Defines validation rules for the <see cref="UpdateEngineTypeDto"/> object.
    /// </summary>
    public UpdateEngineTypeDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The engine type id value cannot be empty.");
        RuleFor(x => x.NewName)
            .NotEmpty().WithMessage("The engine name should not be empty.");
    }
}
