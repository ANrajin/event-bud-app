using EventBud.Application.Contracts;
using EventBud.Application.Contracts.Repositories;

namespace EventBud.Persistence.UnitOfWorks;

public class ApplicationUnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _dbContext;
    
    public ApplicationUnitOfWork(
        IApplicationDbContext dbContext, 
        ICategoryRepository categoryRepository, 
        IMyEventRepository myEventRepository)
    {
        _dbContext = dbContext;
        CategoryRepository = categoryRepository;
        MyEventRepository = myEventRepository;
    }
    
    public ICategoryRepository CategoryRepository { get; }
    
    public IMyEventRepository MyEventRepository { get; }

    public async Task SaveAsync(CancellationToken cancellationToken) => 
        await _dbContext.SaveChangesAsync(cancellationToken);
}
