namespace API.Validators;

using Application.DTOs.Requests;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="CreateEngineTypeDto"/> class.
/// </summary>
public class CreateEngineTypeDtoValidator : AbstractValidator<CreateEngineTypeDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateEngineTypeDtoValidator"/> class.
    /// Defines validation rules for the <see cref="CreateEngineTypeDto"/> object.
    /// </summary>
    public CreateEngineTypeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The engine type name should not be empty.")
            .MaximumLength(30).WithMessage("The engine type name cannot be more than 30 characters.");
    }
}
