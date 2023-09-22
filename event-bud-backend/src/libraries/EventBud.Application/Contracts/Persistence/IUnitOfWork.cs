using EventBud.Domain.Repositories;

namespace EventBud.Application.Contracts.Persistence;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }

    Task SaveAsync(CancellationToken cancellationToken);
}