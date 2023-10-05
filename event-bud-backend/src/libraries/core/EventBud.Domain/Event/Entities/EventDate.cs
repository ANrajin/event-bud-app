using EventBud.Domain._Commons;
using EventBud.Domain.Event.Aggregate;

namespace EventBud.Domain.Event.Entities;

public sealed class EventDate : Entity
{
    public DateOnly Date { get; private set; } = default;

    public TimeOnly Time { get; private set; } = default;
    
    public Guid EventId { get; } = default;
    
    public MyEvent Event { get; } = new();

    public static EventDate Create(DateOnly date, TimeOnly time)
    {
        return new EventDate
        {
            Date = date,
            Time = time
        };
    }
    
    public static EventDate Update(Guid id, DateOnly date, TimeOnly time)
    {
        return new EventDate
        {
            Id = id,
            Date = date,
            Time = time
        };
    }
}
