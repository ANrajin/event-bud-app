using EventBud.Application.Contracts.Persistence;
using EventBud.Domain.Dtos.Category;
using EventBud.Domain.Entities;
using EventBud.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventBud.Persistence.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly IApplicationDbContext _dbContext;

    public CategoryRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<CategoryDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.Select(s => new CategoryDto
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<CategoryDto?> GetByIdAsync(Guid requestId, CancellationToken cancellationToken)
    {
        return await _dbContext.Categories
            .Select(s => new CategoryDto
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description
            })
            .SingleOrDefaultAsync(x => x.Id.Equals(requestId), cancellationToken: cancellationToken);
    }

    public async Task CreateAsync(Category category, CancellationToken cancellationToken)
    {
        await _dbContext.Categories.AddAsync(category, cancellationToken);
    }
}