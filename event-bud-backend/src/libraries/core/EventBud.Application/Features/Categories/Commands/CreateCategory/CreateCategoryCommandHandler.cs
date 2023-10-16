using EventBud.Application.Abstractions.Requests;
using EventBud.Application.Contracts.UnitOfWorks;
using EventBud.Domain._Shared.Results;
using EventBud.Domain.Category;

namespace EventBud.Application.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Title, request.Description);
        
        await _unitOfWork.CategoryRepository.CreateAsync(category, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);

        return Result.Success();
    }
}
