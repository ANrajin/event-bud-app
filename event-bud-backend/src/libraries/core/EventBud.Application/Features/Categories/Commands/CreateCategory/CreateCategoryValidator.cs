using FluentValidation;

namespace EventBud.Application.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .WithMessage("Category {PropertyName} is required!")
            .MaximumLength(255)
            .WithMessage("Category {PropertyName} must not exceed 255 characters!");
    }
}
