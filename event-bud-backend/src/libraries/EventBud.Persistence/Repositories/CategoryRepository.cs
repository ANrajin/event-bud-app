using EventBud.Application.Contracts.Persistence;
using EventBud.Domain.Entities;
using EventBud.Domain.Repositories;

namespace EventBud.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IApplicationDbContext _dbContext;

    public CategoryRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Category category, CancellationToken cancellationToken)
    {
        await _dbContext.Categories.AddAsync(category, cancellationToken);
    }
}