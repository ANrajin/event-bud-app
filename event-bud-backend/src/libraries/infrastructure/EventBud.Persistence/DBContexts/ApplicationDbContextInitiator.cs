using Microsoft.EntityFrameworkCore;

namespace EventBud.Persistence.DBContexts;

public sealed class ApplicationDbContextInitiator
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ApplicationDbContextInitiator(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task InitAsync()
    {
        try
        {
            await _applicationDbContext.Database.MigrateAsync();
        }
        catch (Exception)
        {
            throw new InvalidOperationException("An exception occured while migrating database!");
        }
    }
}
