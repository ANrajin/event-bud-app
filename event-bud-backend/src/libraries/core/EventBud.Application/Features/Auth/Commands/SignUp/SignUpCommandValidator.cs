using FluentValidation;

namespace EventBud.Application.Features.Auth.Commands.SignUp;

public sealed class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotNull()
            .NotEmpty();
    }
}
