﻿using EventBud.Domain.Category;
using EventBud.Domain.Event.Aggregate;
using EventBud.Domain.Event.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBud.Application.Contracts;

public interface IApplicationDbContext : IDisposable, IAsyncDisposable
{
    DbSet<Category> Categories { get; }
    
    DbSet<Event> Events { get; }
    
    DbSet<EventDate> EventDates { get; }
    
    DbSet<Ticket> Tickets { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}