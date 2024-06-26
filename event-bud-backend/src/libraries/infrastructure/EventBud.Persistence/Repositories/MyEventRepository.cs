﻿using EventBud.Application.Contracts;
using EventBud.Application.Contracts.DbContexts;
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
    
    public async Task<IReadOnlyList<MyEventDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //return await _dbContext.Events.AsNoTracking()
        //    .Select(s => new MyEventDto
        //    {
        //        Id = s.Id,
        //        Title = s.Title,
        //        Description = s.Description,
        //        Capacity = s.Capacity,
        //        EventType = s.EventType,
        //        EventLocation = s.EventLocation,
        //        Image = s.Image
        //    }).ToListAsync(cancellationToken);
    }

    public Task<MyEventDto?> GetByIdAsync(Guid requestId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task CreatAsync(MyEvent events, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //await _dbContext.Events.AddAsync(events, cancellationToken);
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
