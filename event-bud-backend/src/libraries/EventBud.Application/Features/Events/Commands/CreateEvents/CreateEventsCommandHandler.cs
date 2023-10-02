using MediatR;
using EventBud.Application.Contracts;
using EventBud.Domain.Event.Aggregate;
using EventBud.Domain.Event.Entities;
using EventBud.Domain.Event.ValueObjects;

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
        var events = Event.Create(
            request.Title,
            request.Description,
            request.EventType,
            request.ToEventLocation(),
            new List<EventDate>(),
            new List<Ticket>(),
            request.Capacity,
            request.Image);

        await _unitOfWork.EventRepository.CreatAsync(events, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
    }
}
