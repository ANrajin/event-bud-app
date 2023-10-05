using EventBud.Application.Features.Categories.Dtos;
using EventBud.Domain.Category;

namespace EventBud.Application.Contracts.Repositories;

public interface ICategoryRepository
{
    Task<IReadOnlyList<CategoryDto>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<CategoryDto?> GetByIdAsync(Guid requestId, CancellationToken cancellationToken);
    
    Task CreateAsync(Category category, CancellationToken cancellationToken);
    
    Task UpdateAsync(Guid requestId, Category category, CancellationToken cancellationToken);
    
    Task DeleteAsync(Guid requestId, CancellationToken cancellationToken);
}
