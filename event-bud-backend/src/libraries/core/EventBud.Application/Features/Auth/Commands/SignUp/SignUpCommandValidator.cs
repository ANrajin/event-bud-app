using FluentValidation;

namespace EventBud.Application.Features.Auth.Commands.SignUp;

public sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage("The {PropertyName} is required!");

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("The {PropertyName} is required!")
            .MinimumLength(5)
            .WithMessage("The {PropertyName} must be minimun 5 character!");
    }
}
