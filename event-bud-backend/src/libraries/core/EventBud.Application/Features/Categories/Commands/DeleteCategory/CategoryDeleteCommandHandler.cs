using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Contracts.UnitOfWorks;
using EventBud.Domain._Shared.Results;

namespace EventBud.Application.Features.Categories.Commands.DeleteCategory;

public sealed class CategoryDeleteCommandHandler : ICommandHandler<CategoryDeleteCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryDeleteCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.CategoryRepository.DeleteAsync(request.Id, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}
