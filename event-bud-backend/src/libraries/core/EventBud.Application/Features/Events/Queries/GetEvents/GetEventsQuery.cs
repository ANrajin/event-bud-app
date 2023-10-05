using MediatR;
using EventBud.Application.Features.Events.Dtos;

namespace EventBud.Application.Features.Events.Queries.GetEvents;

public sealed record GetEventsQuery(CancellationToken CancellationToken) : 
    IRequest<IReadOnlyList<MyEventDto>>;
