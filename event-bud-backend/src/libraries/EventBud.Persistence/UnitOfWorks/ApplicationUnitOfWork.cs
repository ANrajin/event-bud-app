using EventBud.Application.Contracts;
using EventBud.Application.Contracts.Repositories;

namespace EventBud.Persistence.UnitOfWorks;

public class ApplicationUnitOfWork : IUnitOfWork
{
    private readonly IApplicationDbContext _dbContext;
    
    public ApplicationUnitOfWork(
        IApplicationDbContext dbContext, 
        ICategoryRepository categoryRepository, 
        IEventRepository eventRepository)
    {
        _dbContext = dbContext;
        CategoryRepository = categoryRepository;
        EventRepository = eventRepository;
    }
    
    public ICategoryRepository CategoryRepository { get; }
    
    public IEventRepository EventRepository { get; }

    public async Task SaveAsync(CancellationToken cancellationToken) => 
        await _dbContext.SaveChangesAsync(cancellationToken);
}
