using EventBud.Application.Features.Events.Dtos;
using EventBud.Domain.Event.Aggregate;

namespace EventBud.Application.Contracts.Repositories;

public interface IMyEventRepository
{
    Task<IReadOnlyList<MyEventDto>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<MyEventDto?> GetByIdAsync(Guid requestId, CancellationToken cancellationToken);
    
    Task CreatAsync(MyEvent events, CancellationToken cancellationToken);

    Task Update(Guid id, MyEvent events, CancellationToken cancellationToken);

    Task Delete(Guid id, CancellationToken cancellationToken);
}
