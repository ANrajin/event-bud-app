using FluentValidation;

namespace EventBud.Application.Features.IAM.Queries.SignIn
{
    public sealed class SignInQueryValidator : AbstractValidator<SignInQuery>
    {
        public SignInQueryValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("The Email/Username is required!");

            RuleFor(x => x.Password)
                .Cascade(cascadeMode: CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .WithMessage("The {PropertyName} is required!")
                .MinimumLength(5)
                .WithMessage("The {PropertyName} must be minimum 5 character!");
        }
    }
}
