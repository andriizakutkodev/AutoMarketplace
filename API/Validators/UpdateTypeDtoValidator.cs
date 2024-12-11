namespace API.Validators;

using Application.DTOs.Requests;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="UpdateTypeDto"/> class.
/// </summary>
public class UpdateTypeDtoValidator : AbstractValidator<UpdateTypeDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateTypeDtoValidator"/> class.
    /// Defines validation rules for the <see cref="UpdateTypeDto"/> object.
    /// </summary>
    public UpdateTypeDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().NotNull().WithMessage("The type id is required.");
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("The type name is required.");
    }
}
