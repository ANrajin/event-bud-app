using EventBud.Domain.Category;
using Microsoft.EntityFrameworkCore;

namespace EventBud.Application.Contracts;

public interface IApplicationDbContext : IDisposable, IAsyncDisposable
{
    DbSet<Category> Categories { get; }
        
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
