using EventBud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBud.Application.Contracts.Persistence;

public interface IApplicationDbContext : IDisposable, IAsyncDisposable
{
    DbSet<Category> Categories { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}