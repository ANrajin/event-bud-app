using EventBud.Domain._Commons;
using EventBud.Domain.Event.Entities;
using EventBud.Domain.Event.ValueObjects;

namespace EventBud.Domain.Event.Aggregate;

public sealed class Event : Entity
{
    public string Title { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public EventType EventType { get; private set; } = EventType.Online;

    public EventLocation EventLocation { get; private set; } = new();

    public List<EventDate> EventDates { get; private set; } = new();

    public List<Ticket> Tickets { get; private set; } = new();

    public uint Capacity { get; private set; } = 10;
    
    public string Image { get; private set; } = string.Empty;

    public static Event Create(
        string title, 
        string description,
        EventType type,
        EventLocation location,
        List<EventDate> dates,
        List<Ticket> tickets,
        uint capacity,
        string image)
    {
        return new Event
        {
            Title = title,
            Description = description,
            EventType = type,
            EventLocation = location,
            EventDates = dates,
            Tickets = tickets,
            Capacity = capacity,
            Image = image
        };
    }

    public static Event Update(
        Guid id,
        string title, 
        string description,
        EventType type,
        EventLocation location,
        List<EventDate> dates,
        List<Ticket> tickets,
        uint capacity,
        string image)
    {
        return new Event
        {
            Id = id,
            Title = title,
            Description = description,
            EventType = type,
            EventLocation = location,
            EventDates = dates,
            Tickets = tickets,
            Capacity = capacity,
            Image = image
        };
    }
}
