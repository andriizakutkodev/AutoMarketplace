namespace API.Validators;

using Application.DTOs.Requests;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="CreateTypeDto"/> class.
/// </summary>
public class CreateTypeDtoValidator : AbstractValidator<CreateTypeDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateTypeDtoValidator"/> class.
    /// Defines validation rules for the <see cref="CreateTypeDto"/> object.
    /// </summary>
    public CreateTypeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("The type name should not be null or empty.")
            .MaximumLength(30).WithMessage("The type name cannot be more than 30 characters.");
    }
}
