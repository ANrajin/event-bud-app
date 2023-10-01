using EventBud.Application.Contracts;
using EventBud.Domain.Category;
using EventBud.Domain.Event.Aggregate;
using EventBud.Domain.Event.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBud.Persistence.DBContexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        :base(dbContextOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Set Table Name as Application.TableName
        modelBuilder.HasDefaultSchema("Application");
            
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Category> Categories => Set<Category>();

    public DbSet<Event> Events => Set<Event>();

    public DbSet<EventDate> EventDates => Set<EventDate>();

    public DbSet<Ticket> Tickets => Set<Ticket>();
}
