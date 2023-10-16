using EventBud.Domain._Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EventBud.Persistence.Interceptors;

public sealed class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, 
        InterceptionResult<int> result
        )
    {
        var dbContext = eventData.Context;

        if (dbContext is null)
            return base.SavingChanges(eventData, result);

        var entityEntries = dbContext.ChangeTracker.Entries<IAuditableEntity>();

        foreach (var entityEntry in entityEntries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property(x => x.ModifiedAt).CurrentValue = DateTime.UtcNow;
            }
        }

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default
        )
    {
        var dbContext = eventData.Context;

        if (dbContext is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        var entityEntries = dbContext.ChangeTracker.Entries<IAuditableEntity>();

        foreach (var entityEntry in entityEntries)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property(x => x.CreatedAt).CurrentValue = DateTime.UtcNow;
            }

            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property(x => x.ModifiedAt).CurrentValue = DateTime.UtcNow;
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
