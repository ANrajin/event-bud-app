using EventBud.Application.Contracts.Persistence;
using EventBud.Domain.Entities;
using MediatR;

namespace EventBud.Application.Features.Categories.Commands.CreateCategory;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateCategoryCommandHandler(
        IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(request.Title, request.Description);
        
        await _unitOfWork.CategoryRepository.CreateAsync(category, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);
    }
}