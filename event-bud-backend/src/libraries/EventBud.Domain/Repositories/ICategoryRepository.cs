using EventBud.Domain.Entities;

namespace EventBud.Domain.Repositories;

public interface ICategoryRepository
{
    Task CreateAsync(Category category, CancellationToken cancellationToken);
}