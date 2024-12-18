namespace Application.Validators;

using Application.DTOs;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="LoginDto"/> class.
/// Ensures that the email and password properties meet the required validation criteria.
/// </summary>
public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LoginDtoValidator"/> class.
    /// Defines validation rules for the <see cref="LoginDto"/> object.
    /// </summary>
    public LoginDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().NotNull().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Password)
            .NotEmpty().NotNull().WithMessage("Password is required.");
    }
}
