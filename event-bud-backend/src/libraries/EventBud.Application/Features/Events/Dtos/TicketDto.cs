using EventBud.Domain.Event.Enums;

namespace EventBud.Application.Features.Events.Dtos;

public class TicketDto
{
    public string Name { get; set; }

    public uint Inventory { get; set; }

    public uint Price { get; set; }

    public TicketType TicketType { get; set; }

    public string? Description { get; set; }
}
