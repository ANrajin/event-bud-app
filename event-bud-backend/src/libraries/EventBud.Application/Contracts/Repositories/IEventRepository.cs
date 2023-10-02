using EventBud.Application.Features.Events.Dtos;
using EventBud.Domain.Event.Aggregate;

namespace EventBud.Application.Contracts.Repositories;

public interface IEventRepository
{
    Task<IReadOnlyList<EventDto>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<EventDto?> GetByIdAsync(Guid requestId, CancellationToken cancellationToken);
    
    Task CreatAsync(Event events, CancellationToken cancellationToken);

    Task Update(Guid id, Event events, CancellationToken cancellationToken);

    Task Delete(Guid id, CancellationToken cancellationToken);
}
