using EventBud.Domain.Dtos.Category;
using EventBud.Domain.Entities;

namespace EventBud.Domain.Repositories;

public interface ICategoryRepository
{
    Task<IReadOnlyList<CategoryDto>> GetAll(CancellationToken cancellationToken);
    
    Task CreateAsync(Category category, CancellationToken cancellationToken);
}