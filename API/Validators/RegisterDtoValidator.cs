namespace API.Validators;

using Application.DTOs;
using FluentValidation;

/// <summary>
/// Validator for the <see cref="RegisterDto"/> class.
/// Ensures that the email, name, surname, phone number, and password properties meet the required validation criteria.
/// </summary>
public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterDtoValidator"/> class.
    /// Defines validation rules for the <see cref="RegisterDto"/> object.
    /// </summary>
    public RegisterDtoValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().NotNull().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Name)
            .NotEmpty().NotNull().WithMessage("Name is required.");
        RuleFor(x => x.Surname)
            .NotEmpty().NotNull().WithMessage("Surname is required.");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().NotNull().WithMessage("PhoneNumber is required.");
        RuleFor(x => x.Password)
            .NotEmpty().NotNull().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"\d").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");
    }
}
