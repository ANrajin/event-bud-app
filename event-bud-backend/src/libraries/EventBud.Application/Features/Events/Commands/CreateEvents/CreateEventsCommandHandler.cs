using EventBud.Application.Contracts;
using EventBud.Application.Exceptions;
using EventBud.Domain.Event.Aggregate;
using EventBud.Domain.Event.Entities;
using MediatR;

namespace EventBud.Application.Features.Events.Commands.CreateEvents;

public class CreateEventsCommandHandler : IRequestHandler<CreateEventsCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEventsCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CreateEventsCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateEventsCommandValidator();
        var validate = await validator.ValidateAsync(request, cancellationToken);

        if (validate.Errors.Count > 0)
        {
            throw new ValidationException(validate);
        }
        
        var events = MyEvent.Create(
            request.Title,
            request.Description,
            request.EventType,
            request.ToEventLocation(),
            new List<EventDate>(),
            new List<Ticket>(),
            request.Capacity,
            request.Image);

        await _unitOfWork.MyEventRepository.CreatAsync(events, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
    }
}
