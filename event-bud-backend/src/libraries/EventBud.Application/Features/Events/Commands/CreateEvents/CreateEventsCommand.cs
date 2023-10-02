using EventBud.Domain.Event.ValueObjects;
using MediatR;

namespace EventBud.Application.Features.Events.Commands.CreateEvents;

public sealed record CreateEventsCommand : IRequest
{
    public required string Title { get; set; }
    
    public required string Description { get; set; }
    
    public EventType EventType { get; set; }
    
    public required string Location { get; set; }
    
    public required string Street { get; set; }
    
    public required string City { get; set; }
    
    public required string State { get; set; }
    
    public required string Zip { get; set; }
    
    public required string Country { get; set; }
    
    public uint Capacity { get; set; }
    
    public required string Image { get; set; }

    public EventLocation ToEventLocation() => new EventLocation( Location, Street, City, State, Zip, Country);
}
