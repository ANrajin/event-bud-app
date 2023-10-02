using EventBud.Domain.Event.ValueObjects;

namespace EventBud.Application.Features.Events.Dtos;

public class EventDto
{
    public Guid Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public EventType EventType { get; set; }

    public EventLocation EventLocation { get; set; } = new();
    
    public uint Capacity { get; set; }
    
    public string Image { get; set; } = string.Empty;
}
