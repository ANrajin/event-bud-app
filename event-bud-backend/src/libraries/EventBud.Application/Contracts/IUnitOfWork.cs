using EventBud.Application.Contracts.Repositories;

namespace EventBud.Application.Contracts;

public interface IUnitOfWork
{
    ICategoryRepository CategoryRepository { get; }
    
    IMyEventRepository MyEventRepository { get; }

    Task SaveAsync(CancellationToken cancellationToken);
}
