using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Contracts.UnitOfWorks;
using EventBud.Domain._Shared.Results;
using EventBud.Domain.Category;

namespace EventBud.Application.Features.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Title, request.Description);
        await _unitOfWork.CategoryRepository.UpdateAsync(request.Id, category, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}
