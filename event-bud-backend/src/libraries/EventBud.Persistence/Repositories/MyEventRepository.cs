using EventBud.Application.Contracts;
using EventBud.Application.Contracts.Repositories;
using EventBud.Application.Features.Events.Dtos;
using EventBud.Domain.Event.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace EventBud.Persistence.Repositories;

public sealed class MyEventRepository : IMyEventRepository
{
    private readonly IApplicationDbContext _dbContext;

    public MyEventRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IReadOnlyList<EventDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Events.AsNoTracking()
            .Select(s => new EventDto
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Capacity = s.Capacity,
                EventType = s.EventType,
                EventLocation = s.EventLocation,
                Image = s.Image
            }).ToListAsync(cancellationToken);
    }

    public Task<EventDto?> GetByIdAsync(Guid requestId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task CreatAsync(MyEvent events, CancellationToken cancellationToken)
    {
        await _dbContext.Events.AddAsync(events, cancellationToken);
    }

    public Task Update(Guid id, MyEvent events, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
