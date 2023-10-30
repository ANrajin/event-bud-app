using FluentValidation;

namespace EventBud.Application.Features.IAM.Commands.SignUp;

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
            .WithMessage("The {PropertyName} must be minimum 5 character!");
    }
}
