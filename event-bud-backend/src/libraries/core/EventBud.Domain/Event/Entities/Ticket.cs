using EventBud.Domain._Commons;
using EventBud.Domain.Event.Aggregate;
using EventBud.Domain.Event.Enums;

namespace EventBud.Domain.Event.Entities;

public sealed class Ticket : Entity
{
    public string Name { get; private set; } = string.Empty;

    public uint Inventory { get; private set; } = 10;

    public uint Price { get; private set; } = default;

    public TicketType TicketType { get; private set; } = TicketType.Free;

    public string? Description { get; private set; } = null;

    public Guid EventId { get; } = default;
    
    public MyEvent Event { get; } = new();

    public static Ticket Create(
        string name,
        uint inventory,
        uint price,
        TicketType type,
        string description
        )
    {
        return new Ticket
        {
            Name = name,
            Inventory = inventory,
            Price = price,
            TicketType = type,
            Description = description
        };
    }
    
    public static Ticket Update(
        Guid id,
        string name,
        uint inventory,
        uint price,
        TicketType type,
        string description
    )
    {
        return new Ticket
        {
            Id = id,
            Name = name,
            Inventory = inventory,
            Price = price,
            TicketType = type,
            Description = description
        };
    }
}
