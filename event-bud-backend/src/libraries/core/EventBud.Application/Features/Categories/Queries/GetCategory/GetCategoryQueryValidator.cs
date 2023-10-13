using FluentValidation;

namespace EventBud.Application.Features.Categories.Queries.GetCategory;

public sealed class GetCategoryQueryValidator : AbstractValidator<GetCategoryQuery>
{
    public GetCategoryQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("Invalid Category {PropertyName} given!");
    }
}
