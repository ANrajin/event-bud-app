using EventBud.Application.Contracts.Persistence;
using EventBud.Domain.Dtos.Category;
using MediatR;

namespace EventBud.Application.Features.Categories.Queries.GetCategories;

public sealed class GetCategoryQueryHandler : IRequestHandler<GetCategoriesQuery, IReadOnlyList<CategoryDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CategoryRepository.GetAll(cancellationToken);

        return result;
    }
}