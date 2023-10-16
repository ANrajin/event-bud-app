using EventBud.Application.Contracts.DbContexts;
using EventBud.Domain._Shared.IAM.Models;
using EventBud.Domain.Category;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventBud.Persistence.DBContexts;

public class ApplicationDbContext : 
    IdentityDbContext<ApplicationUser, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>,
    IApplicationDbContext
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

        base.OnModelCreating(modelBuilder);
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<ApplicationUser> AspNetUsers => Set<ApplicationUser>();

    public DbSet<Category> Categories => Set<Category>();

    //public DbSet<MyEvent> Events => Set<MyEvent>();

    //public DbSet<EventDate> EventDates => Set<EventDate>();

    //public DbSet<Ticket> Tickets => Set<Ticket>();
}
