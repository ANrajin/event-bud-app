using EventBud.Application.Contracts;
using EventBud.Application.Contracts.UnitOfWorks;
using EventBud.Domain.Category;
using MediatR;

namespace EventBud.Application.Features.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Title, request.Description);
        await _unitOfWork.CategoryRepository.UpdateAsync(request.Id, category, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}
