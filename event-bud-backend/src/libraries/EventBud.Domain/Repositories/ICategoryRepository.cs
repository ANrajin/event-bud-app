using EventBud.Domain.Dtos.Category;
using EventBud.Domain.Entities;

namespace EventBud.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IReadOnlyList<CategoryDto>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<CategoryDto?> GetByIdAsync(Guid requestId, CancellationToken cancellationToken);
    
    Task CreateAsync(Category category, CancellationToken cancellationToken);
}