using EventBud.Application.Contracts.Persistence;
using MediatR;

namespace EventBud.Application.Features.Categories.Commands.DeleteCategory;

public sealed class CategoryDeleteCommandHandler : IRequestHandler<CategoryDeleteCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryDeleteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CategoryRepository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
    }
}
