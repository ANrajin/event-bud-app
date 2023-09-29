using EventBud.Application.Contracts;
using EventBud.Application.Contracts.Repositories;
using EventBud.Application.Exceptions;
using EventBud.Application.Features.Categories.Dtos;
using EventBud.Domain.Category;
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
        return await _dbContext.Categories.AsNoTracking()
            .Select(s => new CategoryDto
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description
            })
            .ToListAsync(cancellationToken);
    }

    public async Task<CategoryDto?> GetByIdAsync(Guid requestId, CancellationToken cancellationToken)
    {
        return await _dbContext.Categories.AsNoTracking()
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

    public async Task UpdateAsync(Guid requestId, Category category, CancellationToken cancellationToken)
    {
        var categoryEntity = await _dbContext.Categories.FindAsync(new object?[] { requestId }, 
            cancellationToken: cancellationToken);
        categoryEntity?.Update(category.Title, category.Description);
    }

    public async Task DeleteAsync(Guid requestId, CancellationToken cancellationToken)
    {
        var categoryEntity = await _dbContext.Categories
            .FindAsync(new object?[] { requestId }, cancellationToken: cancellationToken);

        if (categoryEntity is null) throw new ResourceNotFoundException("The requested resource not found!");

        _dbContext.Categories.Remove(categoryEntity);
    }
}
