using EventBud.Application.Contracts.Persistence;
using EventBud.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventBud.Persistence.DbContexts;

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
}