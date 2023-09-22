using EventBud.Application.Contracts.Persistence;
using EventBud.Domain.Repositories;

namespace EventBud.Persistence.UnitOfWorks;

public class ApplicationUnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _dbContext;
    
    public ApplicationUnitOfWork(
        IApplicationDbContext dbContext, 
        ICategoryRepository categoryRepository)
    {
        _dbContext = dbContext;
        CategoryRepository = categoryRepository;
    }
    
    public ICategoryRepository CategoryRepository { get; }

    public async Task SaveAsync(CancellationToken cancellationToken) => 
        await _dbContext.SaveChangesAsync(cancellationToken);
}