using EventBud.Application.Contracts.Repositories;

namespace EventBud.Application.Contracts;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }

    Task SaveAsync(CancellationToken cancellationToken);
}
