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

    public async Task<IReadOnlyList<CategoryDto>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.Select(s => new CategoryDto(s.Id, s.Title, s.Description))
            .ToListAsync(cancellationToken);
    }

    public async Task CreateAsync(Category category, CancellationToken cancellationToken)
    {
        await _dbContext.Categories.AddAsync(category, cancellationToken);
    }
}