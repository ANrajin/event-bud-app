using EventBud.Domain.Category;
using Microsoft.EntityFrameworkCore;

namespace EventBud.Application.Contracts.DbContexts;

public interface IApplicationDbContext : IDisposable, IAsyncDisposable
{
    DbSet<Category> Categories { get; }
    
    //DbSet<MyEvent> Events { get; }
    
    //DbSet<EventDate> EventDates { get; }
    
    //DbSet<Ticket> Tickets { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
