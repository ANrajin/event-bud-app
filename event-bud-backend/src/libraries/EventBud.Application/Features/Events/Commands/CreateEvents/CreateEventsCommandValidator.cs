using FluentValidation;

namespace EventBud.Application.Features.Events.Commands.CreateEvents;

public sealed class CreateEventsCommandValidator : AbstractValidator<CreateEventsCommand>
{
    public CreateEventsCommandValidator()
    {
        RuleFor(x => x.Title)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event {PropertyName} is required!")
            .MaximumLength(255)
            .WithMessage("Event {PropertyName} must not exceed 255 characters!");
        
        RuleFor(x => x.Description)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event {PropertyName} is required!")
            .MaximumLength(1000)
            .WithMessage("Event {PropertyName} must not exceed 1000 characters!");
        
        RuleFor(x => x.Location)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event {PropertyName} is required!")
            .MaximumLength(255)
            .WithMessage("Event {PropertyName} must not exceed 255 characters!");
        
        RuleFor(x => x.Street)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event {PropertyName} is required!")
            .MaximumLength(255)
            .WithMessage("Event {PropertyName} must not exceed 255 characters!");
            
        RuleFor(x => x.City)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event {PropertyName} is required!")
            .MaximumLength(150)
            .WithMessage("Event {PropertyName} must not exceed 150 characters!");
        
        RuleFor(x => x.State)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event {PropertyName} is required!")
            .MaximumLength(150)
            .WithMessage("Event {PropertyName} must not exceed 150 characters!");
        
        RuleFor(x => x.Zip)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event {PropertyName} is required!")
            .MaximumLength(10)
            .WithMessage("Event {PropertyName} must not exceed 10 characters!");
        
        RuleFor(x => x.Country)
            .Cascade(cascadeMode: CascadeMode.Stop)
            .NotNull()
            .NotEmpty()
            .WithMessage("Event {PropertyName} is required!")
            .MaximumLength(255)
            .WithMessage("Event {PropertyName} must not exceed 255 characters!");
    }
}
